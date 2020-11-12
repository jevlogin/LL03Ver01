using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class SaveData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;

        public override string ToString() => $"Name = {Name} Position = {Position}";
    }
}
