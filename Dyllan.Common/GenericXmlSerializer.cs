using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Dyllan.Common
{
    public class GenericXmlSerializer<T> : AbstractFile where T : class
    {
        private XmlSerializer serializer;

        public GenericXmlSerializer(string fileName)
            : base(fileName)
        {
            serializer = new XmlSerializer(typeof(T));
        }

        public T DescrializeFromFile()
        {
            T result = DescrializeFromFile(serializer, FileName);

            return result;
        }

        public static T DescrializeFromFile(string filePath)
        {
            T result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            result = DescrializeFromFile(serializer, filePath);

            return result;
        }

        private static T DescrializeFromFile(XmlSerializer xmlSerializer, string filePath)
        {
            T result = null;
            if (!string.IsNullOrEmpty(filePath) && xmlSerializer != null)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    result = xmlSerializer.Deserialize(fileStream) as T;
                }
            }
            return result;
        }

        public void SeirlizeToFile(T @object)
        {
            SerializeToFile(serializer, FileName, @object);
        }

        public static void SerializeToFile(string filePath, T @object)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            SerializeToFile(xmlSerializer, filePath, @object);
        }

        private static void SerializeToFile(XmlSerializer xmlSerializer, string filePath, T @object)
        {
            if (!string.IsNullOrEmpty(filePath) && xmlSerializer != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.Unicode))
                {
                    xmlSerializer.Serialize(streamWriter, @object);
                }
            }
        }
    }
}
