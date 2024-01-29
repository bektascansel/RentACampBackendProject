using Entities.Concrete.DTOs.CustomerDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerValidator() {

            RuleFor(p => p.CompanyName).NotNull().WithMessage("Company Name cannot be null");
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Company Name cannot be empty");
            RuleFor(p => p.CompanyName).MinimumLength(2).WithMessage("Company Name must be at least 2 characters long");

            RuleFor(p=>p.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0");
            RuleFor(p => p.UserId).NotNull().WithMessage("User ID cannot be null");
        }
    }
}
