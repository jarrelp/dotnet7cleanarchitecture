namespace CleanArchitecture.Domain.Entities;

public class Question : BaseAuditableEntity
{
    public string? Description { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<Option>? Options { get; private set; }
}
