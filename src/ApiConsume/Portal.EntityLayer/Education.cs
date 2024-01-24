using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.EntityLayer
{
    public class Education
    {
        public Education()
        {
            AddingTime = DateTime.Now;
        }
        [Key]
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public string EducationDescribtion { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Kontenjan { get; set; }
        public string ImageFile { get; set; }
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
