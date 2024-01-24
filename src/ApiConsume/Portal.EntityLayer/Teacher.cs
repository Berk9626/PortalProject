using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.EntityLayer
{
    public class Teacher //eğitmen
    {
        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Describtion { get; set; }
        public string TeacherMail { get; set; }
        public string ImageFile { get; set; }
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public string Phone { get; set; }
        public string SocialMedia1 { get; set; }


        public int EducationId { get; set; }
        [JsonIgnore]
        public virtual Education Education { get; set; }

        public int TeacherInfoId { get; set; }

        [JsonIgnore]
        public virtual TeacherInfo TeacherInfo { get; set; }





    }
}
