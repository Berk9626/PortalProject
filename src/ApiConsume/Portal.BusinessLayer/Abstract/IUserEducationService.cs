using Portal.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BusinessLayer.Abstract
{
    public interface IUserEducationService : IGenericService<UserEducation>
    {
        List<UserEducation> ListedByUserId(int id);
    }
}
