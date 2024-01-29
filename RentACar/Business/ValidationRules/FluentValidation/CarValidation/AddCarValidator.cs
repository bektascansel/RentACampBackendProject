using Entities.Concrete.DTOs.BrandDto;
using Entities.Concrete.DTOs.CarDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CarValidation
{    public  class AddCarValidator :AbstractValidator<AddCarDto>
    {

        public AddCarValidator() {

            RuleFor(p => p.Name).NotNull().WithMessage("Name cannot be null");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters long");

            RuleFor(p=>p.BrandId).GreaterThan(0).WithMessage("Brand Id must be greater than 0");
            RuleFor(p=>p.BrandId).NotNull().WithMessage("Brand Id cannot be null");

            RuleFor(p => p.ColorId).GreaterThan(0).WithMessage("Color Id must be greater than 0");
            RuleFor(p => p.ColorId).NotNull().WithMessage("Color Id cannot be null");

            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Daily Price  must be greater than 0");
            RuleFor(p => p.DailyPrice).NotNull().WithMessage("Daily Price cannot be null");


            RuleFor(p => p.Description).NotNull().WithMessage("Description cannot be null");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("Description must be at least 2 characters long");


            RuleFor(p => p.ModelYear).GreaterThan(1900).WithMessage("Model Year  must be greater than 1900");
            RuleFor(p => p.ModelYear).NotNull().WithMessage("Model Year cannot be null");


        }
    }
}
