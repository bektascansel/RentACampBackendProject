using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustumorId { get; set; }

        [ForeignKey("CarId")]
        [JsonIgnore]
        public Car Car { get; set; }

        [ForeignKey("CustumorId")]
        [JsonIgnore]
        public Customer Customer{ get; set; }

       
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
       

    }
}
