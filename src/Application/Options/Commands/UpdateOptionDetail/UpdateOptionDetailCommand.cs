using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Options.Commands.UpdateOptionDetail;

public record UpdateOptionDetailCommand : IRequest
{
    public int Id { get; init; }

    public int QuestionId { get; init; }

    public IList<int>? SkillIds { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Description { get; init; }
}

public class UpdateOptionDetailCommandHandler : IRequestHandler<UpdateOptionDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOptionDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOptionDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Options
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Option), request.Id);
        }

        entity.QuestionId = request.QuestionId;
        entity.SkillIds = request.SkillIds;
        entity.Priority = request.Priority;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
