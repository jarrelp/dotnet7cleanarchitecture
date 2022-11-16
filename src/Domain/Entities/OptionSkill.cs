namespace CleanArchitecture.Domain.Entities;

public class OptionSkill : BaseAuditableEntity
{
    public PriorityLevel Priority { get; set; }

    public int SkillId { get; set; }
    public Skill Skills { get; set; }

    public int OptionId { get; set; }
    public Option Options { get; set; }
}
