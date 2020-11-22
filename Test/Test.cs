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
            var a = "  @!  asfds 752 4asd 54";
            Debug.Log(a.TrySingle());
        }

    }
}
