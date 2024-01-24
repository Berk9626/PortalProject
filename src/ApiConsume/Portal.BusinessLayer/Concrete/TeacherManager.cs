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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void TDelete(Teacher t)
        {
            _teacherDal.Delete(t);
        }

        public Teacher TGetById(int id)
        {
            return _teacherDal.GetById(id);
        }

        public List<Teacher> TGetList()
        {
            return _teacherDal.GetList();
        }

        public void TInsert(Teacher t)
        {
            _teacherDal.Insert(t);
        }

        public void TUpdate(Teacher t)
        {
            _teacherDal.Update(t);
        }
    }
}
