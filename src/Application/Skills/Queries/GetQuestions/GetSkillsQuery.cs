using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Skills.Queries.GetSkills;

//[Authorize]
public record GetSkillsQuery : IRequest<List<SkillDto>>;

public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, List<SkillDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSkillsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SkillDto>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Skills
                .AsNoTracking()
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    }
}
