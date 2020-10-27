using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class SaveData<T> : BaseExample<Guid>
    {
        public T Position;
        public SaveData(Guid id) : base(id)
        {
            IdPlayer = id;
        }
    }
}
