using Portal.EntityLayer;
using System.Text.Json.Serialization;

namespace Portal.WEBUI.Dtos.UserEducationDto
{
    public class ResultUserEducationDto
    {
        public int Id { get; set; }

        public int EducationId { get; set; }

        public bool IsCourseFinished { get; set; }




        //Relational Properties
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }
        [JsonIgnore]
        public virtual Education Education { get; set; }
    }
}
