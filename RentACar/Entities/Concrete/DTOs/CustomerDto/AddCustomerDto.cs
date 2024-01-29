using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.CustomerDto
{
    public class AddCustomerDto
    {

        public int UserId { get; set; }
        public string CompanyName { get; set; }


    }
}
