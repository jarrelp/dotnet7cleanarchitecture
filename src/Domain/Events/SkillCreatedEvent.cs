namespace CleanArchitecture.Domain.Events;

public class SkillCreatedEvent : BaseEvent
{
    public SkillCreatedEvent(Skill skill)
    {
        Skill = skill;
    }

    public Skill Skill { get; }
}
