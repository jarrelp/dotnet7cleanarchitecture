namespace CleanArchitecture.Domain.Entities;

public class Result : BaseAuditableEntity
{
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public string ApplicationUserId { get; set; } = null!;
    public ApplicationUser ApplicationUser { get; set; } = null!;

    public IList<Option> Options { get; set; } = new List<Option>();
}

/***
 * Result wordt per quiz per user opgeslagen in database
 * 
 * 
 * **/