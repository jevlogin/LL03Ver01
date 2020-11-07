using System;
using System.Collections;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(3.14f);
            list.Add("Text");
            list.Add(new int[] { 1, 2, 3 });
            foreach (var element in list)
            {
                Debug.Log($"{element}");
            }
        }

    }
}
