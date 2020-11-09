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
            Addition(1, 2, 3, 4, 5);
            int[] array = new int[] { 5, 4, 3, 2, 1 };
            Addition(array);
            Addition();
        }

        private void Addition(params int[] integers)
        {
            for (int i = 0; i < integers.Length; i++)
            {
                Debug.Log(integers[i]);
            }
        }
    }

    internal class User
    {
        private string[] Names =
        {
            "Roman",
            "Ilya",
            "Igor",
            "Lera"
        };

        public IEnumerable<string> UserName 
        { 
            get
            {
                for (int i = 0; i < Names.Length; i++)
                {
                    yield return Names[i];
                }
            }
        }
    }
}
