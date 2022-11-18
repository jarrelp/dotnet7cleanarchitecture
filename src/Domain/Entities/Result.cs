namespace CleanArchitecture.Domain.Entities;

public class Result  : BaseAuditableEntity
{
    public IList<Option>? Options { get; set; }
}
