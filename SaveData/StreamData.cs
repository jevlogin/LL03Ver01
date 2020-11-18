using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public class StreamData : IData<SaveData>
    {
        public SaveData Load(string path = null)
        {
            var result = new SaveData();
            using (var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    result.Name = streamReader.ReadLine();
                    result.Position.X = streamReader.ReadLine().TrySingle();
                    result.Position.X = streamReader.ReadLine().TrySingle();
                    result.Position.X = streamReader.ReadLine().TrySingle();
                    result.IsEnabled = streamReader.ReadLine().TryBool();
                }
            }
            return result;
        }

        public List<SaveData> LoadList(string path = null)
        {
            throw new System.NotImplementedException();
        }

        public void Save(SaveData data, string path = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data.Name);
                streamWriter.WriteLine(data.Position.X);
                streamWriter.WriteLine(data.Position.Y);
                streamWriter.WriteLine(data.Position.Z);
                streamWriter.WriteLine(data.IsEnabled);
            }
        }

        public void SaveList(List<SaveData> saveAll, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.Log($"Файл или директория отсутствует {path}");
                return;
            }

            using (var streamWriter = new StreamWriter(path))
            {
                foreach (var item in saveAll)
                {
                    streamWriter.WriteLine(item.Name);
                    streamWriter.WriteLine(item.Position.X);
                    streamWriter.WriteLine(item.Position.Y);
                    streamWriter.WriteLine(item.Position.Z);
                    streamWriter.WriteLine(item.IsEnabled);
                }
            }
        }
    }
}
