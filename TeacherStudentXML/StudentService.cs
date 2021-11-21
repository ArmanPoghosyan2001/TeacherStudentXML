using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentXML.Models;

namespace TeacherStudentXML
{
    public class StudentService : IStudentService
    {

        private readonly IXMLManager<StudentModel> _studentManager;
        private readonly IXMLManager<TeacherModel> _teacherManager;

        public StudentService(IXMLManager<StudentModel> studentManager, IXMLManager<TeacherModel> teacherManager)
        {

            _studentManager = studentManager;
            _teacherManager = teacherManager;
        }
        public void Add(StudentModel student)
        {
            if (TeacherValidation(student))
            {
                List<StudentModel> students = new List<StudentModel>();
                try
                {
                    students = _studentManager.Read();
                }
                catch (Exception ex)
                {

                }

                students.Add(student);

                _studentManager.Insert(students);
            }
            else
            {
                Console.WriteLine($"There is no teacher of student with Id:{student.Id}");
            }


        }

        public void Delete(int id)
        {
            List<StudentModel> students = _studentManager.Read();
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    students.Remove(student);
                    _studentManager.Update(students);
                    break;
                }
            }
        }

        public StudentModel Get(int id)
        {
            List<StudentModel> students = _studentManager.Read();
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public List<StudentModel> GetAll()
        {
            return _studentManager.Read();
        }
        public void Update(StudentModel student)
        {
            if (TeacherValidation(student))
            {
                List<StudentModel> students = new List<StudentModel>();
                try
                {
                    students = _studentManager.Read();
                }
                catch (Exception ex)
                {

                }
                bool isConsist = false;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == student.Id)
                    {
                        students[i] = student;
                        isConsist = true;
                        break;
                    }
                }
                if (isConsist)
                {
                    _studentManager.Update(students);

                }
                else
                {
                    Console.WriteLine($"There is no student with Id{student.Id}");
                }

            }
            else
            {
                Console.WriteLine($"There is no teacher of student with Id:{student.Id}");
            }


        }
        private bool TeacherValidation(StudentModel student)
        {
            List<TeacherModel> teachers = null;
            try
            {
                teachers = _teacherManager.Read();
            }
            catch (Exception ex)
            {
            }
            int isConsist = 0;
            if (student.Teacher != null)
            {
                isConsist = 2;
                if (teachers != null)
                {
                    foreach (var teacher in teachers)
                    {
                        if (teacher.Id == student.Teacher.Id && teacher.Name == student.Teacher.Name && teacher.Age == student.Teacher.Age)
                        {
                            isConsist = 1;
                        }
                    }

                }
            }
            if (isConsist == 0 || isConsist == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
