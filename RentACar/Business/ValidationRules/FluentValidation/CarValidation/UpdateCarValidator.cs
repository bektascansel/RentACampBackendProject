using Entities.Concrete.DTOs.CarDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CarValidation
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
    {

        public UpdateCarValidator() {

            RuleFor(p => p.Id).GreaterThan(0).WithMessage("ID must be greater than 0");
            RuleFor(p => p.Id).NotNull().WithMessage("ID cannot be null");

            RuleFor(p => p.Name).MinimumLength(2).When(p => !string.IsNullOrEmpty(p.Name)).WithMessage("Name must be at least 2 characters long");

            RuleFor(p => p.BrandId).GreaterThan(0).When(p =>  p.BrandId!=0).WithMessage("Brand Id must be greater than 0");
            

            RuleFor(p => p.ColorId).GreaterThan(0).When(p =>  p.ColorId != 0).WithMessage("Color Id must be greater than 0");
          

            RuleFor(p => p.DailyPrice).GreaterThan(0).When(p => p.DailyPrice != 0).WithMessage("Daily Price  must be greater than 0");
           
            RuleFor(p => p.Description).MinimumLength(2).When(p => !string.IsNullOrEmpty(p.Description)).WithMessage("Description must be at least 2 characters long");

            RuleFor(p => p.ModelYear).GreaterThan(1900).When(p => p.ModelYear != 0).WithMessage("Model Year  must be greater than 1900");
           

        }
    }
}
