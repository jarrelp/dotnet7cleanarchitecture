using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Options.Queries.GetOptionsWithPagination;

public class OptionBriefDto : IMapFrom<Option>
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public IList<int>? SkillIds { get; set; }

    public string? Description { get; set; }
}
