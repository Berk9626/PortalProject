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
    public class EfTeacherInfoDal : GenericRepository<TeacherInfo>, ITeacherInfoDal
    {
        public EfTeacherInfoDal(Context context) : base(context)
        {
        }
    }
}
