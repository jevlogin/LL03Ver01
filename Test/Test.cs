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
            BaseExample<int> data2 = new SaveData<int>(3775);
            SaveData<Guid> data1 = new SaveData<Guid>(Guid.NewGuid());
        }
    }
}
