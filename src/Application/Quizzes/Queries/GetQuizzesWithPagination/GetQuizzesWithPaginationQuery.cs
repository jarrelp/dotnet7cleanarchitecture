using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Quizzes.Queries.GetQuizzesWithPagination;

public record GetQuizzesWithPaginationQuery : IRequest<PaginatedList<QuizDto>>
{
    public int? QuizId { get; init; }
    public bool? Active { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetQuizzesWithPaginationQueryHandler : IRequestHandler<GetQuizzesWithPaginationQuery, PaginatedList<QuizDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuizzesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<QuizDto>> Handle(GetQuizzesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Quizzes
            .Where(x => x.Id == request.QuizId || x.Active == request.Active)
            .ProjectTo<QuizDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
