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
    public class AppUserProfileManager : IAppUserProfileService
    {
        private readonly IAppUserProfileDal _appUserProfileDal;

        public AppUserProfileManager(IAppUserProfileDal appUserProfileDal)
        {
            _appUserProfileDal = appUserProfileDal;
        }

        public void TDelete(AppUserProfile t)
        {
            _appUserProfileDal.Delete(t);
        }

        public AppUserProfile TGetById(int id)
        {
            return _appUserProfileDal.GetById(id);
        }

        public List<AppUserProfile> TGetList()
        {
            return _appUserProfileDal.GetList();
        }

        public void TInsert(AppUserProfile t)
        {
            _appUserProfileDal.Insert(t);
        }

        public void TUpdate(AppUserProfile t)
        {
            _appUserProfileDal.Update(t);
        }
    }
}
