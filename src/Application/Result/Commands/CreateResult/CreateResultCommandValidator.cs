using FluentValidation;

namespace CleanArchitecture.Application.Results.Commands.CreateResult;

public class CreateResultCommandValidator : AbstractValidator<CreateResultCommand>
{
    public CreateResultCommandValidator()
    {
        RuleFor(v => v.Options)
            .NotEmpty();
    }
}
