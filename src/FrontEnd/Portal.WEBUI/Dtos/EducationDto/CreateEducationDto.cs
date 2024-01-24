using Portal.EntityLayer;
using System.Text.Json.Serialization;

namespace Portal.WEBUI.Dtos.EducationDto
{
    public class CreateEducationDto
    {
        public CreateEducationDto()
        {
            AddingTime = DateTime.Now;
        }
        //[Key]
        
        public string EducationName { get; set; }
        public string EducationDescribtion { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Kontenjan { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime AddingTime { get; set; }

        public int CategoryId { get; set; }

        //Relational Properties
        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual List<UserEducation> UserEducations { get; set; }
        [JsonIgnore]
        public virtual List<Teacher> Teachers { get; set; }
    }
}
