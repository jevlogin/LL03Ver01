using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class SaveData<T, R, U> : BaseExample<R>
        where T : U
    {
        public T Position;
        public SaveData(R id) : base(id)
        {
            IdPlayer = id;
        }
    }
}
