using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Results.Queries.GetResultsWithPagination;

public record GetResultsWithPaginationQuery : IRequest<PaginatedList<ResultBriefDto>>
{
    public int QuestionId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResultsWithPaginationQueryHandler : IRequestHandler<GetResultsWithPaginationQuery, PaginatedList<ResultBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetResultsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ResultBriefDto>> Handle(GetResultsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Options
            .Where(x => x.QuestionId == request.QuestionId)
            .OrderBy(x => x.Description)
            .ProjectTo<ResultBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
