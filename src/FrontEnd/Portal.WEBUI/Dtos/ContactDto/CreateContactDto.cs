using Portal.EntityLayer;
using System.Text.Json.Serialization;

namespace Portal.WEBUI.Dtos.ContactDto
{

    public class CreateContactDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }


        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }
    }
 }

