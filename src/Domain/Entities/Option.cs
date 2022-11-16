namespace CleanArchitecture.Domain.Entities;

public class Option : BaseAuditableEntity
{
    public int QuestionId { get; set; }

    public string? Description { get; set; }

    public PriorityLevel Priority { get; set; }

    public Question Question { get; set; } = null!;

    public IList<Skill> Skills { get; private set; } = new List<Skill>();
}
