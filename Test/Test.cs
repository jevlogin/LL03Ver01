using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            Division("5", "1");
        }

        private void Division(string inputA, string inputB)
        {
            if (!Int32.TryParse(inputA, out var a))
            {
                Debug.Log($"Плохое число {inputA}");
            }
            else if (!Int32.TryParse(inputB, out var b))
            {
                Debug.Log($"Плохое число {inputB}");
            }
            else if (b == 0)
            {
                Debug.Log($"Деление на ноль {b}");
            }
            else
            {
                var x = a / b;
                Debug.Log($"{a} / {b} = {x}");
            }
        }
    }
}
