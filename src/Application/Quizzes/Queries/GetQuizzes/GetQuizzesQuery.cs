using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Quizzes.Queries.GetQuizzes;

//[Authorize]
public record GetQuizzesQuery : IRequest<List<QuizDto>>;

public class GetQuizsQueryHandler : IRequestHandler<GetQuizzesQuery, List<QuizDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuizsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuizDto>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Quizzes
                .AsNoTracking()
                .ProjectTo<QuizDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    }
}
