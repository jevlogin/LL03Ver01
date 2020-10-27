using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            BaseExample<string> data = new BaseExample<string>("name_235");
            BaseExample<Guid> data1 = new SaveData<int, Guid, object>(Guid.NewGuid());
            SaveData<int, Guid, object> data2 = new SaveData<int, Guid, object>(Guid.NewGuid());
        }
    }
}
