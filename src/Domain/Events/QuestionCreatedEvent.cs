namespace CleanArchitecture.Domain.Events;

public class QuestionCreatedEvent : BaseEvent
{
    public QuestionCreatedEvent(Question question)
    {
        Question = question;
    }

    public Question Question { get; }
}
