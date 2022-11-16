using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Options.Queries.GetOptionsWithPagination;

public record GetOptionsWithPaginationQuery : IRequest<PaginatedList<OptionBriefDto>>
{
    public int QuestionId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetOptionsWithPaginationQueryHandler : IRequestHandler<GetOptionsWithPaginationQuery, PaginatedList<OptionBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOptionsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OptionBriefDto>> Handle(GetOptionsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Options
            .Where(x => x.QuestionId == request.QuestionId)
            .OrderBy(x => x.Description)
            .ProjectTo<OptionBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
