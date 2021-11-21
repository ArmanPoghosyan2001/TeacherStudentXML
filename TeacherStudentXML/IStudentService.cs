using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentXML.Models;

namespace TeacherStudentXML
{
    public interface IStudentService
    {
        void Add(StudentModel student);
        void Update(StudentModel student);
        void Delete(int id);
        StudentModel Get(int id);
        List<StudentModel> GetAll();
    }
}
