using FluentValidation;

namespace CleanArchitecture.Application.Options.Commands.UpdateOptionDetail;

public class UpdateOptionDetailCommandValidator : AbstractValidator<UpdateOptionDetailCommand>
{
    public UpdateOptionDetailCommandValidator()
    {
        RuleFor(v => v.Description)
            .MaximumLength(200);
    }
}
