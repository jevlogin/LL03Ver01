using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            using (StreamReader reader = new StreamReader("example path"))
            {
                //  Работаем с объектом
            }   //  Неявно вызывается функция Dispose()
            //  Объект выгружен из памяти
        }
    }
}
