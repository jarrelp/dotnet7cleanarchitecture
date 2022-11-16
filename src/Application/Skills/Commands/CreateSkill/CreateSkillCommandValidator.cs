using FluentValidation;

namespace CleanArchitecture.Application.Skills.Commands.CreateSkill;

public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
    }
}
