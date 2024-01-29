using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.RentalDto
{
    public class UpdateRentalDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustumorId { get; set; }
        [JsonIgnore]
        public DateTime? RentDate { get; set; }
        [JsonIgnore]
        public DateTime? ReturnDate { get; set; }
        public DateTime? ReturnDateOnly
        {
            get
            {
                // Eğer ReturnDate null ise, null döndür
                if (ReturnDate == null)
                    return null;

                // Eğer ReturnDate değeri varsa, sadece tarih kısmını al ve saat kısmını sıfırla
                return ReturnDate.Value.Date;
            }
            set
            {
                // Gelen değeri ReturnDate özelliğine atama
                ReturnDate = value;
            }
        }

        public DateTime? RentDateOnly
        {
            get
            {
                if (RentDate == null)
                    return null;
                return RentDate.Value.Date;
            }
            set
            {
                RentDate = value;
            }
        }

    }
}
