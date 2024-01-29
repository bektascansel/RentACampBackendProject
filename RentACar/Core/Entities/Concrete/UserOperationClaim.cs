using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }

        [ForeignKey("OperationClaimId")]
        [JsonIgnore]
        public OperationClaim OperationClaim { get; set; }
    }
}
