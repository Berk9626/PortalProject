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
    public class EducationManager : IEducationService
    {
        private readonly IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public void TDelete(Education t)
        {
            _educationDal.Delete(t);
        }

        public Education TGetById(int id)
        {
            return _educationDal.GetById(id);
        }

        public List<Education> TGetList()
        {
            return _educationDal.GetList();
        }

        public void TInsert(Education t)
        {
            _educationDal.Insert(t);
        }

        public void TUpdate(Education t)
        {
            _educationDal.Update(t);
        }
    }
}
