namespace CleanArchitecture.Domain.Entities;

public class Result : BaseAuditableEntity
{
    public int ResultId { get; set; }

    public IList<Option>? Options { get; set; }

    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

    public ApplicationUser ApplicationUser { get; set; } = null!;
}

/***
 * Result wordt per quiz per user opgeslagen in database
 * 
 * 
 * **/