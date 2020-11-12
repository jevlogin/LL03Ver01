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
    }
}
