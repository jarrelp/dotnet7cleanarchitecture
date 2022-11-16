namespace CleanArchitecture.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public string? Name { get; set; }

    public IList<Option>? Options { get; private set; }
    public IList<OptionSkill>? OptionSkills { get; set; }
}
