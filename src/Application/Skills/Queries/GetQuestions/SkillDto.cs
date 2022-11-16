using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Skills.Queries.GetSkills;

public class SkillDto : IMapFrom<Skill>
{
    public int Id { get; set; }

    public string? Name { get; set; }
}
