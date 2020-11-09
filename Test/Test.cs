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
            int[] nums = { 10, -19, 4, 7, 2, -5, 0 };
            // Запрос, который получает значения в отсортированном порядке
            var posNums = from n in nums
                          where n > 0
                          orderby n ascending
                          select n;
            Console.WriteLine("Values in Upper: ");

            List<int> a = posNums.ToList();

            foreach (int i in posNums)
            {
                Debug.Log($"{i} ");
            }

            nums[1] = 10;

            Debug.Log("\n" + posNums.Sum());

            foreach (var el in posNums)
            {
                Debug.Log(el);
            }
        }

    }
}
