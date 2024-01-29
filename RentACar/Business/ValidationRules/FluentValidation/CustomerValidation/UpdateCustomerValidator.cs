using Entities.Concrete.DTOs.CustomerDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidator() {

            RuleFor(p=>p.Id).GreaterThan(0).WithMessage("ID must be greater than 0");
            RuleFor(p=>p.Id).NotNull().WithMessage("ID cannot be null");

            RuleFor(p => p.CompanyName).MinimumLength(2).When(p => !string.IsNullOrEmpty(p.CompanyName)).WithMessage("Company Name must be at least 2 characters long");

            RuleFor(p => p.UserId).GreaterThan(0).When(p => p.UserId != 0).WithMessage("User Id must be greater than 0");

        }
    }
}
