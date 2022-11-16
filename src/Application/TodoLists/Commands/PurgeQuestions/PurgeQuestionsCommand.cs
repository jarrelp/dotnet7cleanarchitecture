using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using MediatR;

namespace CleanArchitecture.Application.TodoLists.Commands.PurgeQuestions;

//[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "CanPurge")]
public record PurgeQuestionsCommand : IRequest;

public class PurgeQuestionsCommandHandler : IRequestHandler<PurgeQuestionsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeQuestionsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PurgeQuestionsCommand request, CancellationToken cancellationToken)
    {
        _context.Questions.RemoveRange(_context.Questions);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
