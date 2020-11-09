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
            // Все массивы в С# неявным образом преобразуются в форму интерфейса IEnumerable<T>
            // Благодаря этому любой массив в С# может служить в качестве источника данных, извлекаемых 
            // по запросу Linq 
            int[] nums = { 1, -2, 3, 0, -4, 5 };
            // Создадим запрос, получающий только положительные числа  
            // posNums – переменная запроса
            // Ей присваивается результат выполнения запроса
            var posNums = from n       // n -переменная диапазона (как в foreach)
                    in nums  // Источник данных
                          where n > 0  // Предикат (условие) – фильтр данных
                          select n;      // Какие данные получаем? В сложных запросах здесь можно указать,например, фамилию адресата вместо всего адреса
            Debug.Log("Положительные числа: ");
            // Выполняем запрос и выводим положительные числа на экран
            foreach (int i in posNums)
            {
                Debug.Log(i + " ");
            }
        }

    }
}
