﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.CustomerDto
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
    }
}
