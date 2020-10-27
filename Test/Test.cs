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
            BaseExample<Guid> data1 = new SaveData<Vector3>(Guid.NewGuid());
            SaveData<Vector3> data2 = new SaveData<Vector3>(Guid.NewGuid());
        }
    }
}
