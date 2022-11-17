namespace CleanArchitecture.Domain.Entities;

public class Option : BaseAuditableEntity
{
    public string? Description { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public IList<OptionSkill>? OptionSkills { get; set; }
}
