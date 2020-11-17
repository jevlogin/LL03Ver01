using System.Collections.Generic;

namespace JevLogin
{
    public interface IData<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);
        void Save(List<T> saveAll, string fullPath);
        string JSONSerialize<T>(T obj, string fullPath);
    }
}
