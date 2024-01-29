using Entities.Concrete.DTOs.RentalDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.RentalValidation
{
    public  class AddRentalValidator : AbstractValidator<AddRentalDto>
    {
        public AddRentalValidator() {

            RuleFor(p=>p.CarId).GreaterThan(0).WithMessage("Car Id must be greater than 0");
            RuleFor(p => p.CarId).NotNull().WithMessage("Car Id cannot be null");

            RuleFor(p => p.CustumorId).GreaterThan(0).WithMessage("Custumor Id must be greater than 0");
            RuleFor(p => p.CustumorId).NotNull().WithMessage("Custumor Id cannot be null");
  
            RuleFor(p => p.RentDateOnly).NotEmpty().NotNull().WithMessage("Rent date cannot be empty.");
         

        }
    }
}
