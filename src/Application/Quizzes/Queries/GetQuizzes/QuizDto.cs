using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Quizzes.Queries.GetQuizzes;

public class QuizDto : IMapFrom<Quiz>
{
    public QuizDto()
    {
        Questions = new List<QuestionDto>();
    }

    public int Id { get; set; }

    public string? Description { get; set; }

    public IList<QuestionDto> Questions { get; set; }
}
