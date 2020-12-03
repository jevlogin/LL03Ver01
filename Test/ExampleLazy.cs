using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleLazy : MonoBehaviour
    {
        public sealed class Singleton
        {
            private Singleton() { }

            private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

            public static Singleton Instance => _instance.Value;

            public void Test()
            {
                Debug.Log("Hello World");
            }
        }

        private void Start()
        {
            Singleton.Instance.Test();
        }
    }
}
