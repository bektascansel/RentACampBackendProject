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
    public class LoginUserValidator : AbstractValidator<UserForLoginDto>
    {

        public LoginUserValidator() {

            RuleFor(p => p.Email).NotNull().WithMessage("Email cannot be null");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.Email).Must(BeValidEmailFormat).WithMessage("Please use a valid email format.");

            RuleFor(p => p.Password).NotNull().WithMessage("Password cannot be null");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty");
  
        }



        private bool BeValidEmailFormat(string arg)
        {
          
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(arg, emailPattern);
        }



    }
   
}
