using System;
using System.Runtime.Serialization;


namespace JevLogin
{
    [Serializable]
    [DataContract]
    public sealed class SaveData
    {
        [DataMember]
        public string Name;
        [DataMember]
        public Vector3Serializable Position;
        [DataMember]
        public bool IsEnabled;

        public override string ToString() => $"Name = {Name} Position = {Position} IsVisible = {IsEnabled}";
    }
}
