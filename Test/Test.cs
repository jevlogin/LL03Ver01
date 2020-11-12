using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {

        private void Start()
        {
            ExampleLinq exampleLinq = new ExampleLinq();
            exampleLinq.Projection();
        }

    }
}
