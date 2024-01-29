using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class Car : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }


        [ForeignKey("ColorId")]
        [JsonIgnore]
        public Color Color { get; set; }


        [ForeignKey("BrandId")]
        [JsonIgnore]
        public Brand Brand { get; set; }
            
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
