namespace CleanArchitecture.Domain.Events.Result;

public class ResultCreatedEvent : BaseEvent
{
    public ResultCreatedEvent(Entities.Result Result)
    {
        Result = Result;
    }

    public Entities.Result Result { get; }
}
