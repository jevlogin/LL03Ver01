using UnityEngine;


namespace JevLogin
{
    public sealed class SaveData<T> where T : struct
    {
        public int CountBonuses;
        public T IdPlayer = default;
    }
}
