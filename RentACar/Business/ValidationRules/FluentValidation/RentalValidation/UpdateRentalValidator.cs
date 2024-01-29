using Entities.Concrete;
using Entities.Concrete.DTOs.RentalDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.ValidationRules.FluentValidation.RentalValidation
{
    public class UpdateRentalValidator : AbstractValidator<UpdateRentalDto>
    {
        public UpdateRentalValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("ID must be greater than 0");
            RuleFor(p => p.Id).NotNull().WithMessage("ID cannot be null");

            RuleFor(p => p.CarId).GreaterThan(0).When(p => p.CarId != 0).WithMessage("Car Id must be greater than 0");

            RuleFor(p => p.CustumorId).GreaterThan(0).When(p => p.CustumorId != 0).WithMessage("Custumor Id must be greater than 0");
            

          
            RuleFor(p => p.ReturnDateOnly)
           .Must((p, returnDateOnly) =>
           {
               if (p.ReturnDate.HasValue && p.RentDate.HasValue)
               {
                
                   return p.ReturnDate.Value.Date >= p.RentDate.Value.Date;
               }

               return true;
           })
           .WithMessage("ReturnDateOnly should be bigger than or equal to RentDateOnly.");

        }
    }

    
}

