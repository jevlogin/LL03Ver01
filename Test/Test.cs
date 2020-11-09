﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            ExampleGetOrAddComponent();
        }

        private void ExampleGetOrAddComponent()
        {
            gameObject.GetOrAddComponent<Rigidbody>();
        }

        private void ExampleIsOneOf()
        {
            var arr = new[] { 1, 5, 6, 3 };

            var t = 7;

            foreach (var i in arr)
            {
                if (i == 7)
                {
                    Debug.Log($"Нашли с помощью foreach");
                }
                else
                {
                    Debug.Log($"Not");
                }
            }

            if (t.IsOneOf(5, 8, 6, 3, 7))
            {
                Debug.Log($"Нашли с помощью метода расширения");
            }
            else
            {
                Debug.Log($"Not");
            }
        }

        private void ExampleTryBool(string v)
        {
            bool res = v.TryBool();
            Debug.Log(res);
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
