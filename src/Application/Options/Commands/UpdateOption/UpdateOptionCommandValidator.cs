using FluentValidation;

namespace CleanArchitecture.Application.Options.Commands.UpdateOption;

public class UpdateOptionCommandValidator : AbstractValidator<UpdateOptionCommand>
{
    public UpdateOptionCommandValidator()
    {
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
    }
}
