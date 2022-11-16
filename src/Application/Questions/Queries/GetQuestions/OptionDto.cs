using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Questions.Queries.GetQuestions;

public class OptionDto : IMapFrom<Option>
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string? Description { get; set; }

    public int Priority { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Option, OptionDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}
