using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Models;

public class OptionDetailDto : IMapFrom<Option>
{
    public OptionDetailDto()
    {
        OptionSkills = new List<OptionSkillDto>();
    }

    public int Id { get; set; }

    public int QuestionId { get; set; }

    public IList<OptionSkillDto> OptionSkills { get; set; }

    public string Description { get; set; } = null!;
}
