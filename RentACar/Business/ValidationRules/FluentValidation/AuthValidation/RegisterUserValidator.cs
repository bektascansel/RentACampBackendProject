using Entities.Concrete.DTOs.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.AuthValidation
{
    public class RegisterUserValidator : AbstractValidator<UserForRegisterDto>
    {

        public RegisterUserValidator() {


            RuleFor(p => p.FirstName).NotNull().WithMessage("First Name cannot be null");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("First Name must be at least 2 characters long");

            RuleFor(p => p.LastName).NotNull().WithMessage("Last Name cannot be null");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name cannot be empty");
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Last Name must be at least 2 characters long");

            RuleFor(p => p.Email).NotNull().WithMessage("Email cannot be null");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.Email).Must(BeValidEmailFormat).WithMessage("Please use a valid email format.");

            RuleFor(p => p.Password).NotNull().WithMessage("Password cannot be null");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(p => p.Password).Must(BeValidPassword).WithMessage("Please use a valid password format.");


        }

        private bool BeValidPassword(string arg)
        {
          
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).{8,}$";
            return Regex.IsMatch(arg, passwordPattern);
        }

        private bool BeValidEmailFormat(string arg)
        {
          
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(arg, emailPattern);
        }



    }
}
