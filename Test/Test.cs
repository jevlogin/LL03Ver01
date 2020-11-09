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
            string[] strs = { ".com", ".net", "hsNameA.com", "hsNameB.net",
                "test", ".network", "hsNameC.net", "hsNameD.com" };
            // Create a query that obtains Internet addresses that end with .net
            // Создадим запрос, который получает все Интернет-адреса, заканчивающиеся на .net
            var netAddrs = from addr in strs
                           where addr.Length > 4
                                 && addr.EndsWith(".net", StringComparison.Ordinal)
                           // Он  возвращает логическое значение true, если вызывающая его строка оканчивается 
                           // последовательностью символов, указываемой в качестве аргумента этого метода 
                           // Сортировка результатов запроса с помощью оператора orderby 
                           select addr;
            // Выполним запрос и выведем результаты    
            foreach (var str in netAddrs)
            {
                Debug.Log(str);
            }

        }

    }
}
