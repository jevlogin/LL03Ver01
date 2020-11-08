using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleStack : MonoBehaviour
    {
        public void Main()
        {
            var arr = new Stack<int>(4);

            arr.Push(1); // 1
            arr.Push(1); // 1 1
            arr.Push(5); // 5 1 1
            arr.Push(2); // 2 5 1 1

            Debug.Log(arr.Peek()); // 2 5 1 1
            Debug.Log(arr.Pop()); // 5 1 1
        }

    }
}
