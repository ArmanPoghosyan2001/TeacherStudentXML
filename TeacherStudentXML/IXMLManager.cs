using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudentXML
{
    public interface IXMLManager<T> where T : class
    {
        void Insert(List<T> source);
        void Update(List<T> source);
        List<T> Read();
    }
}
