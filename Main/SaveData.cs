using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class SaveData : BaseExample<Guid>
    {
        public SaveData(Guid id) : base(id)
        {
            IdPlayer = id;
        }
    }
}
