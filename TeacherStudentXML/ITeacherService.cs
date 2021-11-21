using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentXML.Models;

namespace TeacherStudentXML
{
    interface ITeacherService
    {
        void Add(TeacherModel teacher);
        void Update(TeacherModel teacher);
        void Delete(int id);
        TeacherModel Get(int id);
        List<TeacherModel> GetAll();
    }
}
