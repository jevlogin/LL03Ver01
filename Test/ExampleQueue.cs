using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleQueue : MonoBehaviour
    {
        public void Main()
        {
            var arr = new Queue<int>(4);

            arr.Enqueue(1); //1
            arr.Enqueue(1); //1
            arr.Enqueue(5); //5
            arr.Enqueue(2); //2

            Debug.Log(arr.Peek());      //1152
            Debug.Log(arr.Dequeue());   //152
        }
    }
}
