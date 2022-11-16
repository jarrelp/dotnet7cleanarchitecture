namespace CleanArchitecture.Application.Questions.Queries.GetQuestions;

public class TodosVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
}
