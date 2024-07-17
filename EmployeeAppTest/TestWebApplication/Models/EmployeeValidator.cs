using FluentValidation;

namespace TestWebApplication.Models
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
       public EmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Username is Required.")
                .Length(5, 30).WithMessage("Username must be between 5 and 30 characters.");
          
        }
    }
   
}
