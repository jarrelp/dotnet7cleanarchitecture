namespace CleanArchitecture.Domain.Entities;

public class Quiz : BaseAuditableEntity
{
    public string? Description { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<Question>? Questions { get; set; }
}
