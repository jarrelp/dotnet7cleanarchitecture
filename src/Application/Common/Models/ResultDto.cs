using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Models;

public class ResultDto : IMapFrom<Result>
{
    public ResultDto()
    {
        Options = new List<OptionDto>();
    }

    public int Id { get; set; }

    public int QuizId { get; set; }

    public string ApplicationUserId { get; set; } = null!;

    public IList<OptionDto> Options { get; set; }
}
