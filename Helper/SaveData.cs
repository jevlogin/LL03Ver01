using System;
using System.Collections.Generic;
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

        [DataMember]
        public string TypeObject;

        public override string ToString() => $"Name = {Name} Position = {Position} IsVisible = {IsEnabled} TypeObject = {TypeObject}";
    }
}
