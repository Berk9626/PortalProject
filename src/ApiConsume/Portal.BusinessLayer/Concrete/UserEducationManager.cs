using Portal.BusinessLayer.Abstract;
using Portal.DataAccessLayer.Abstract;
using Portal.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BusinessLayer.Concrete
{
    public class UserEducationManager : IUserEducationService
    {
        private readonly IUserEducationDal _userEducationDal;

        public UserEducationManager(IUserEducationDal userEducationDal)
        {
            _userEducationDal = userEducationDal;
        }

        public List<UserEducation> ListedByUserId(int id)
        {
           return  _userEducationDal.ListedByUserId(id);
        }

        public void TDelete(UserEducation t)
        {
            _userEducationDal.Delete(t);
        }

        public UserEducation TGetById(int id)
        {
           return _userEducationDal.GetById(id);
        }

        public List<UserEducation> TGetList()
        {
            return _userEducationDal.GetList();
        }

        public void TInsert(UserEducation t)
        {
            _userEducationDal.Insert(t);
        }

        public void TUpdate(UserEducation t)
        {
            _userEducationDal.Update(t);
        }
    }
}
