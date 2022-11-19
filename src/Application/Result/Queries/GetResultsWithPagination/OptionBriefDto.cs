using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Results.Queries.GetResultsWithPagination;

public class OptionBriefDto : IMapFrom<Option>
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public IList<OptionSkill>? OptionSkills { get; set; }

    public string? Description { get; set; }
}
