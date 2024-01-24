using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.DataAccessLayer.Abstract;
using Portal.DataAccessLayer.Concrete;
using Portal.DataAccessLayer.Repositories.Concrete;
using Portal.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataAccessLayer.EntityFramework
{
    public class EfUserEducationDal : GenericRepository<UserEducation>, IUserEducationDal
    {
        
        public EfUserEducationDal(Context context) : base(context)
        {
            
            
           
        }

        public List<UserEducation> ListedByUserId(int id)
        {
            Context context = new Context();    
           
          var model = context.UserEducations.Include(x=>x.Education).Where(x => x.Id == id).ToList();
            //context.UserEducations.Include(x=>x.Ed)

             context.SaveChanges();
            return model;
            





        }
    }
}
