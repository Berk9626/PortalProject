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
    public class TeacherInfoManager : ITeacherInfoService
    {
        private readonly ITeacherInfoDal _teacherInfoDal;

        public TeacherInfoManager(ITeacherInfoDal teacherinfodal)
        {
            _teacherInfoDal = teacherinfodal;
        }

        public void TDelete(TeacherInfo t)
        {
            _teacherInfoDal.Delete(t);
        }

        public TeacherInfo TGetById(int id)
        {
            return _teacherInfoDal.GetById(id);
        }

        public List<TeacherInfo> TGetList()
        {
            return _teacherInfoDal.GetList();
        }

        public void TInsert(TeacherInfo t)
        {
            _teacherInfoDal.Insert(t);
        }

        public void TUpdate(TeacherInfo t)
        {
            _teacherInfoDal.Update(t);
        }
    }
}
