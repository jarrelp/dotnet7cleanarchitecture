namespace CleanArchitecture.Domain.Events;

public class OptionCreatedEvent : BaseEvent
{
    public OptionCreatedEvent(Option option)
    {
        Option = option;
    }

    public Option Option { get; }
}
