using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BrandValidation
{
    public class UpdateBrandValidator : AbstractValidator<Brand>
    {

        public UpdateBrandValidator()
        {
            RuleFor(p =>p.Id).GreaterThan(0).WithMessage("ID must be greater than 0");

            RuleFor(p => p.Id).NotNull().WithMessage("ID cannot be null");

            RuleFor(p => p.Name).NotNull().WithMessage("Name cannot be null");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters long");



        }
    }
}
