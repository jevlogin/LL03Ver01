using System;
using UnityEngine;

namespace JevLogin
{
    public sealed class ExampleEvent
    {
        public event Action Test = delegate { };  //  подписались пустым делегатом на событие

        public void StartMethod()
        {
            Test.Invoke();
        }
    }
}
