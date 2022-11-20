using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.Result;
using MediatR;

namespace CleanArchitecture.Application.Results.Commands.CreateResult;

public record CreateResultCommand : IRequest<int>
{
    public IList<Option> Options { get; init; } = null!;
}

public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateResultCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateResultCommand request, CancellationToken cancellationToken)
    {
        var entity = new Result
        {
            Options = request.Options
        };

        entity.AddDomainEvent(new ResultCreatedEvent(entity));

        _context.Results.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
