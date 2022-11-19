namespace CleanArchitecture.Domain.Entities;

public class Quiz : BaseAuditableEntity
{
    public string? Description { get; set; }

    public bool Active { get; set; } = false;

    public IList<Question>? Questions { get; set; }
}
