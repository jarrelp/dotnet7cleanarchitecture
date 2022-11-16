using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.TodoLists.Queries.GetQuestions;

//[Authorize]
public record GetPriorityLevelsQuery : IRequest<List<PriorityLevelDto>>;

public class GetPriorityLevelsQueryHandler : IRequestHandler<GetPriorityLevelsQuery, List<PriorityLevelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPriorityLevelsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PriorityLevelDto>> Handle(GetPriorityLevelsQuery request, CancellationToken cancellationToken)
    {
        return Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList();
    }
}
