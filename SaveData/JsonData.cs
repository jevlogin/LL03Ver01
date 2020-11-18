using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System;
using System.Text;

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
            throw new NotImplementedException();
        }

        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str));
            //File.WriteAllText(path, str);
        }

        public void Save(List<T> saveAll, string path)
        {

        }
    }
}
