﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.CarDto
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string? Name { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string? Description { get; set; }
    }
}
