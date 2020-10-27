using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var saveData = new SaveData<Guid, Vector3>
            {
                IdPlayer = new Guid(),
                Position = Vector3.one
            };


            //var saveData = new SaveData<Guid>
            //{
            //    IdPlayer = new Guid()
            //};

            //var savedDataExample = new SaveData<string>
            //{
            //    IdPlayer = "name_235"
            //};
        }
    }
}
