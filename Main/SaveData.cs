using UnityEngine;


namespace JevLogin
{
    public sealed class SaveData<T> : BaseExample<T>
    {
        public SaveData(T id) : base(id)
        {
            IdPlayer = id;
        }
    }
}
