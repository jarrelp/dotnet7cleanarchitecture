namespace CleanArchitecture.Domain.Events.Result;

public class ResultDeletedEvent : BaseEvent
{
    public ResultDeletedEvent(Entities.Result Result)
    {
        Result = Result;
    }

    public Entities.Result Result { get; }
}
