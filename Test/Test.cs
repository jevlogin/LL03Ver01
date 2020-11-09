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
            AddToList();
        }

        private void AddToList()
        {
            var list = new List<int>();
            var list2 = new List<int>();

            list.Add(1);

            1.AddTo(list).AddTo(list2);
            2.AddTo(list2);

            foreach (var l1 in list)
            {
                Debug.Log(l1);
            }

            foreach (var l2 in list2)
            {
                Debug.Log(l2);
            }
        }
    }
}
