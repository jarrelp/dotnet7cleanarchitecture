using FluentValidation;

namespace CleanArchitecture.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotNull().WithMessage("Name is required.")
            .NotEmpty().WithMessage("Name is required.");
    }
}
