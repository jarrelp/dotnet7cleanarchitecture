using FluentValidation;

namespace CleanArchitecture.Application.Options.Commands.CreateOption;

public class CreateOptionCommandValidator : AbstractValidator<CreateOptionCommand>
{
    public CreateOptionCommandValidator()
    {
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
    }
}
