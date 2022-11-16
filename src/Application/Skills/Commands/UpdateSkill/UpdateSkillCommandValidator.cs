using FluentValidation;

namespace CleanArchitecture.Application.Skills.Commands.UpdateSkill;

public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
{
    public UpdateSkillCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
    }
}
