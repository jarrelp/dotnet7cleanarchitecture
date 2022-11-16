namespace CleanArchitecture.Domain.Events;

public class QuestionDeletedEvent : BaseEvent
{
    public QuestionDeletedEvent(Question question)
    {
        Question = question;
    }

    public Question Question { get; }
}
