using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.EntityLayer
{
    public class UserEducation //kullanıcının sahip olduğu kurslar 
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
