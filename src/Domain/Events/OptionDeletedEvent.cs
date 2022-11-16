namespace CleanArchitecture.Domain.Events;

public class OptionDeletedEvent : BaseEvent
{
    public OptionDeletedEvent(Option option)
    {
        Option = option;
    }

    public Option Option { get; }
}
