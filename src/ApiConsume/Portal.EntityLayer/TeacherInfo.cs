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
    public class TeacherInfo
    {
        [Key]
        public int TeacherInfoId { get; set; }
        public string TeacherInfoDescribtion { get; set; }

        [JsonIgnore]
        public virtual List<Teacher> Teachers { get; set; }
    }
}
