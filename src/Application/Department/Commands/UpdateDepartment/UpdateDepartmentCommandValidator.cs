using FluentValidation;

namespace CleanArchitecture.Application.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotNull().WithMessage("Name is required.")
            .NotEmpty().WithMessage("Name is required.");
    }
}
