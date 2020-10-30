using System;
using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        // Этот обобщенный делегат может вызывать любой метод, который возвращает void и принимает 
        //  единственный параметр типа
        private delegate void MyGenericDelegate<T>(T arg);
        
        private void Start()
        {
            // Зарегистрировать цели
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            // А можно просто указать метод
            MyGenericDelegate<int> intTarget = IntTarget;
            intTarget(9);
        }

        private void StringTarget(string arg)
        {
            print($"arg in uppercase is: {arg.ToUpper()}");
        }

        private void IntTarget(int arg)
        {
            print($"++arg is: {++arg}");
        }
    }
}
