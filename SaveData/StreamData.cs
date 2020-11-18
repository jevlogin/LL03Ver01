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
                    result.Position.Y = streamReader.ReadLine().TrySingle();
                    result.Position.Z = streamReader.ReadLine().TrySingle();
                    result.IsEnabled = streamReader.ReadLine().TryBool();
                }
            }
            return result;
        }

        public List<SaveData> LoadList(string path = null)
        {
            var result = new List<SaveData>();
            var data = new SaveData();
            using (var streamReader = new StreamReader(path))
            {
                var textData = File.ReadAllText(path);

                var array = textData.Split('\n');
                string[] dataArray;

                for (int i = 0; i < array.Length; i++)
                {
                    dataArray = array[i].Split(' ');
                    data.Name = dataArray[0];
                    data.Position.X = dataArray[1].TrySingle();
                    data.Position.Y = dataArray[2].TrySingle();
                    data.Position.Z = dataArray[3].TrySingle();
                    data.IsEnabled = dataArray[4].TryBool();
                    data.AddTo(result);
                }

                return result;
            }
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
                    streamWriter.Write(item.Name);
                    streamWriter.Write(" ");
                    streamWriter.Write(item.Position.X);
                    streamWriter.Write(" ");
                    streamWriter.Write(item.Position.Y);
                    streamWriter.Write(" ");
                    streamWriter.Write(item.Position.Z);
                    streamWriter.Write(" ");
                    streamWriter.WriteLine(item.IsEnabled);
                }
            }
        }
    }
}
