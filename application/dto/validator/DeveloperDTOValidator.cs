using FluentValidation;

namespace e07.application.dto.validator;

public class DeveloperDTOValidator : AbstractValidator<DeveloperDTO>  // https://docs.fluentvalidation.net/en/latest/aspnet.html#asp-net-core
{
    public DeveloperDTOValidator()
    {

        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(d => d.FirstName)
            .MinimumLength(3).WithMessage("First name must be at least 3 characters long")
            .MaximumLength(20).WithMessage("First name must be at most 20 characters long");

        RuleFor(d => d.LastName)
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters long")
            .MaximumLength(30).WithMessage("Last name must be at most 30 characters long");

        RuleFor(d => d.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0");

        RuleFor(d => d.WorkedHours)
            .GreaterThan(30).WithMessage("Worked hours must be greater than 30")
            .LessThan(50).WithMessage("Worked hours must be less than 50");

        RuleFor(d => d.SalaryByHours)
            .GreaterThan(13).WithMessage("Salary by hours must be greater than 13");

        RuleFor(d => d.DeveloperTypeId)
            .InclusiveBetween(1, 4).WithMessage("Developer type id must be between 1 and 4");
    }
}