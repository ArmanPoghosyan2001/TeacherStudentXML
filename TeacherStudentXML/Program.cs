using System;
using System.Collections.Generic;
using TeacherStudentXML.Models;

namespace TeacherStudentXML
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService(new XMLManager<StudentModel>("students.xml"), new XMLManager<TeacherModel>("teachers.xml"));

            studentService.Add(new StudentModel(5, "Movses", 19));
            studentService.Add(new StudentModel(7, "Karine", 21));
            studentService.Add(new StudentModel(6, "Vaspur", 27));

            StudentModel student = studentService.Get(5);

            studentService.Delete(5);

            List<StudentModel> studentModels = studentService.GetAll();

            studentService.Update(new StudentModel(6, "Gayane", 26));

            TeacherService teacherService = new TeacherService(new XMLManager<TeacherModel>("teachers.xml"), new XMLManager<StudentModel>("students.xml"));

            teacherService.Add(new TeacherModel(1, "Anna", 25));
            teacherService.Add(new TeacherModel { Id = 2, Name = "Narine", Age = 30, Students = studentService.GetAll() });
            teacherService.Add(new TeacherModel(3, "Aram", 32));

            StudentModel st = new StudentModel(1, "Anna", 21);
            st.Teacher = new TeacherModel(1, "Anna", 25);

            studentService.Add(st);
        }
    }
}
