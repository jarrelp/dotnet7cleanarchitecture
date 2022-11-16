using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Questions.Queries.GetQuestions;

public class QuestionDto : IMapFrom<Question>
{
    public QuestionDto()
    {
        Options = new List<OptionDto>();
    }

    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Colour { get; set; }

    public IList<OptionDto> Options { get; set; }
}
