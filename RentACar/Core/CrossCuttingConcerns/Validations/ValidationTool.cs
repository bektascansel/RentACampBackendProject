using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool 
    {
        public static void Validate(IValidator validator,object entity)
        {
            var content= new ValidationContext<object>(entity);
            var result= validator.Validate(content);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
