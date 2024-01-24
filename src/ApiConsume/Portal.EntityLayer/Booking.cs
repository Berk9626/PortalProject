using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.EntityLayer
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }


        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }




    }
}
