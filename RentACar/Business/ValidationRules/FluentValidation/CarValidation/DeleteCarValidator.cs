﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CarValidation
{
    public class DeleteCarValidator : AbstractValidator<int>
    {
        public DeleteCarValidator() {

            RuleFor(id => id).GreaterThan(0).WithMessage("ID must be greater than 0");

            RuleFor(id => id).NotNull().WithMessage("ID cannot be null");

        }
    }
}