using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            IEnumerable<int> reversed = array.Reverse<int>();
        }

        private void Reverse<T>(T[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                T temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
    }
}
