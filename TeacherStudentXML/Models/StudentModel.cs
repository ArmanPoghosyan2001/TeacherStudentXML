using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudentXML.Models
{
    [Serializable]
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public TeacherModel Teacher { get; set; }
        public StudentModel()
        {

        }
        public StudentModel(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

    }
}
