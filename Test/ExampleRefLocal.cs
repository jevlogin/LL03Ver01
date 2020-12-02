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
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ref int numberRef = ref Find(4, numbers);

            Debug.Log(numberRef);
        }

        private ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i];  // возвращаем ссылку на адрес, а не само значение
                }
            }
            throw new IndexOutOfRangeException("numbers not fount");
        }
    }
}
