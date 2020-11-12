using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        public class EmailAddress
        {
            public string Name { get; }
            public string Address { get; }
            public EmailAddress(string n, string a)
            {
                Name = n;
                Address = a;
            }

        }
        private void Start()
        {
            ExampleLinq exampleLinq = new ExampleLinq();
            exampleLinq.Projection();
        }

    }
}
