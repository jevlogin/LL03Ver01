using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace JevLogin
{
    public sealed class BinarySerializationData<T> : IData<T>
    {
        private static BinaryFormatter _formatter;

        public BinarySerializationData()
        {
            _formatter = new BinaryFormatter();
        }

        public T Load(string path)
        {
            T result;
            if (!File.Exists(path))
            {
                throw new ArgumentException("File not found");
            }
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                result = (T)_formatter.Deserialize(fileStream);
            }
            return result;
        }

        public void Save(T data, string path = null)
        {
            if (data == null && !string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Нет данных или отстутствует путь");
            }
            if (!typeof(T).IsSerializable)
            {
                throw new InvalidOperationException("объект не сериализован");
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fileStream, data);
            }
        }
    }
}
