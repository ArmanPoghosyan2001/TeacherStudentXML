using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentXML.Models;

namespace TeacherStudentXML
{
    public class TeacherService : ITeacherService
    {
        private readonly IXMLManager<TeacherModel> _teacherManager;
        private readonly IXMLManager<StudentModel> _studentManager;
        public TeacherService(IXMLManager<TeacherModel> teacherManager, IXMLManager<StudentModel> studentmanager)
        {
            _teacherManager = teacherManager;
            _studentManager = studentmanager;
        }
        public void Add(TeacherModel teacher)
        {
            if (StudentValidation(teacher))
            {
                List<TeacherModel> teachers = new List<TeacherModel>();
                try
                {
                    teachers = _teacherManager.Read(); ;
                }
                catch (Exception ex)
                {

                }
                teachers.Add(teacher);
                _teacherManager.Insert(teachers);
            }
            else
            {
                Console.WriteLine($"There are not all students in XML of teacher with Id:{teacher.Id}");
            }


        }

        public void Delete(int id)
        {
            List<TeacherModel> teachers = _teacherManager.Read();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == id)
                {
                    teachers.Remove(teacher);
                    _teacherManager.Update(teachers);
                    break;
                }
            }
        }

        public TeacherModel Get(int id)
        {
            TeacherModel teacherModel = null;
            List<TeacherModel> teachers = _teacherManager.Read();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == id)
                {
                    teacherModel = teacher;
                    return teacherModel;
                }
            }
            return teacherModel;

        }

        public List<TeacherModel> GetAll()
        {
            return _teacherManager.Read();
        }

        public void Update(TeacherModel teacher)
        {
            if (StudentValidation(teacher))
            {
                List<TeacherModel> teachers = null;
                try
                {
                    teachers = _teacherManager.Read();
                }
                catch (Exception ex)
                {

                }
                bool isConsist = false;
                for (int i = 0; i < teachers.Count; i++)
                {
                    if (teachers[i].Id == teacher.Id)
                    {
                        teachers[i] = teacher;
                        isConsist = true;
                        break;
                    }
                }
                if (isConsist)
                {
                    _teacherManager.Update(teachers);

                }
                else
                {
                    Console.WriteLine($"There is no teacher with Id{teacher.Id}");
                }

            }
            else
            {
                Console.WriteLine($"There are not all students of teacher with Id:{teacher.Id}");
            }
        }
        private bool StudentValidation(TeacherModel teacher)
        {
            List<StudentModel> students = null;
            try
            {
                students = _studentManager.Read();
            }
            catch (Exception ex)
            {
            }
            int isConsist = 0;
            int counter = 0;
            if (teacher.Students != null)
            {
                isConsist = 2;
                if (students != null)
                {

                    foreach (var student in students)
                    {
                        foreach (var tStudent in teacher.Students)
                        {
                            if (tStudent.Id == student.Id && tStudent.Name == student.Name && tStudent.Age == student.Age)
                            {
                                isConsist = 1;
                                counter++;
                            }
                        }
                    }

                }
            }
            if (isConsist == 0 || isConsist == 1 && teacher.Students.Count - counter == 0)
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
