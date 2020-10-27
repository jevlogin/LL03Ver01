using System;
using UnityEngine;


namespace JevLogin
{
    /// <summary>
    /// Аргумент типа, предоставляемый в качестве T, должен совпадать с аргументом, предоставляемым в качестве U, или быть производным от него.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="U"></typeparam>
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
