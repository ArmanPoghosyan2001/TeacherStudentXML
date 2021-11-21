using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeacherStudentXML
{
    public class XMLManager<T> : IXMLManager<T> where T : class
    {
        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
        private readonly string _path;
        public XMLManager(string path)
        {
            _path = path;

        }
        public void Insert(List<T> source)
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, source);
            }
        }
        public List<T> Read()
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                List<T> students = (List<T>)xmlSerializer.Deserialize(fs);

                return students;
            }
        }
        public void Update(List<T> source)
        {
            using (StreamWriter wr = new StreamWriter(_path))
            {
                xmlSerializer.Serialize(wr, source);
            }
        }
    }
}
