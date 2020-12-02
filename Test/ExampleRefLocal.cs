using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleRefLocal : MonoBehaviour
    {
        private void Start()
        {
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Debug.Log(readonlyArgument);
        }

        private void InArgExample(in int number)
        {
            //number = 19;  //не получиться, так как эта переменная только для чтения
        }
    }
}
