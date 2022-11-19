using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Quizzes.Queries.GetQuizzes;

public class QuestionDto : IMapFrom<Question>
{
    public int Id { get; set; }

    public string? Description { get; set; }
}
