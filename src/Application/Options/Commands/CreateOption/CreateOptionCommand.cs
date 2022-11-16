using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Options.Commands.CreateOption;

public record CreateOptionCommand : IRequest<int>
{
    public int QuestionId { get; init; }

    public string? Description { get; init; }
}

public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOptionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Option
        {
            QuestionId = request.QuestionId,
            Description = request.Description
        };

        entity.AddDomainEvent(new OptionCreatedEvent(entity));

        _context.Options.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
