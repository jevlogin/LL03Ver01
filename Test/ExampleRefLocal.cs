using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleRefLocal : MonoBehaviour
    {
        private void Start()
        {
            int temp = 42;
            ref int tempReference = ref temp;
            Debug.Log(temp);
            tempReference = 123;
            Debug.Log(temp);
            temp = 321;
            Debug.Log(tempReference);
            int tempSecond = 24;
            tempReference = ref tempSecond;
            Debug.Log(tempReference);


        }
    }
}
