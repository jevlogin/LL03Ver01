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
            int[] nums = { 1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10 };
            var posNums = from n in nums 
                          where n > 0
                          where n < 10
                          select n;
            Debug.Log("Positive numbers less than 10:");
            foreach (int i in posNums)
            {
                Debug.Log(i + " ");
            }
        }

    }
}
