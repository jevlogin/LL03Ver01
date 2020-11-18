using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace JevLogin
{
    public class SerializableXMLData<T> : IData<T>
    {
        private static XmlSerializer _xmlSerializer;

        public SerializableXMLData()
        {
            _xmlSerializer = new XmlSerializer(typeof(T));
        }

        
        public string JSONSerialize<T1>(T1 obj, string fullPath)
        {
            throw new System.NotImplementedException();
        }

        public T Load(string path)
        {
            T result;
            if (!File.Exists(path))
            {
                return default;
            }
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                result = (T)_xmlSerializer.Deserialize(fileStream);
            }
            return result;
        }

        public List<T> LoadList(string path = null)
        {
            throw new System.NotImplementedException();
        }

        public void Save(T data, string path = null)
        {
            if (data == null && !string.IsNullOrEmpty(path))
            {
                return;
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                _xmlSerializer.Serialize(fileStream, data);
            }
        }

        public void SaveList(List<T> saveAll, string fullPath)
        {
            throw new System.NotImplementedException();
        }
    }
}
