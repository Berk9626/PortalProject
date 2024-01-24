

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Portal.EntityLayer
{
    public class AppUser: IdentityUser<int>
    {

       
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        [JsonIgnore]
        public virtual AppUserProfile AppUserProfile { get; set; }
        [JsonIgnore]
        public virtual List<UserEducation> UserEducations { get; set; }
        [JsonIgnore]
        public List<Booking> Bookings { get; set; }
       

        //public DataStatus Status { get; set; }


    }
}
