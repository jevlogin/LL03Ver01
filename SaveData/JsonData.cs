using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System;


namespace JevLogin
{
    public sealed class JsonData<T> : IData<T>
    {
        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
            //return JsonUtility.FromJson<T>(str);
        }

        public List<T> LoadList(string path = null)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var newList = jsonSerializer.ReadObject(fileStream) as List<T>;
                return newList;
            }
        }
        
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            //File.WriteAllText(path, Crypto.CryptoXOR(str));

            var _path = Path.Combine(Application.dataPath, "dataSave", "1.txt");
            var txt = File.ReadAllText(_path);

            File.WriteAllText(path, Crypto.CryptoJEVLOGIN(txt));

            //File.WriteAllText(path, str);
        }

        public void SaveList(List<T> saveAll, string path)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
               jsonSerializer.WriteObject(fileStream, saveAll);
            }
        }
    }
}
