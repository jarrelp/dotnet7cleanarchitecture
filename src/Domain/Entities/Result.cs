namespace CleanArchitecture.Domain.Entities;

public class Result  : BaseAuditableEntity
{
    public int ResultId { get; set; }
    public IList<Option>? Options { get; set; }
}

/***
 * Result wordt per quiz per user opgeslagen in database
 * 
 * 
 * **/