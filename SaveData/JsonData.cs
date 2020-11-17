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

        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str));
            //File.WriteAllText(path, str);
        }

        public void Save(List<T> saveAll, string fullPath)
        {
            string result = string.Empty;
        }

        public T Deserialize<T1>(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);
        }

        public string JSONSerialize<T1>(T1 obj, string fullPath)
        {
            string retVal = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(ms, obj);
                var byteArray = ms.ToArray();
                retVal = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }
            File.WriteAllText(fullPath, retVal);
            return retVal;
        }
    }
}
