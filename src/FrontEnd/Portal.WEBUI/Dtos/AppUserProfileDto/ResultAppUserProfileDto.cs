using Portal.EntityLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Portal.WEBUI.Dtos.AppUserProfileDto
{
    public class ResultAppUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string ImageFile { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }







        //Relational Properties
        [JsonIgnore]
        [ForeignKey("Id")]
        public virtual AppUser AppUser { get; set; }
    }
}
