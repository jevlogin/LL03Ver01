using System;
using System.Runtime.Serialization;


namespace JevLogin
{
    [Serializable]
    [DataContract]
    public sealed class SaveData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;

        public override string ToString() => $"Name = {Name} Position = {Position} IsVisible = {IsEnabled}";
    }
}
