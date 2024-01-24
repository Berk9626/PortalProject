using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.EntityLayer
{
    public class Category
    {
        //online, sınıf içi eğitim, kitap, sunum, makale, mini proje 
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        

        //[JsonIgnore]
        //public List<Teacher> Teachers { get; set; }

        [JsonIgnore]
        public virtual List<Education> Educations { get; set; }
      



    }
}
