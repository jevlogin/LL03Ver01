using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Lesson05Task04 : MonoBehaviour
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four", 4 },
            {"two", 2 },
            {"one", 1 },
            {"three", 3 }
        };

        private void Start()
        {
            Debug.Log($"Свернутый делегат. стандарт");
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            Debug.Log($"#########################");
            Debug.Log($"Используем лямбду");
            var d2 = dict.OrderBy(dict2 => dict2.Value);
            foreach (var pair in d2)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            Debug.Log($"#########################");
            Debug.Log($"Используем вынос делегата");
            var d3 = dict.OrderBy(MyPredicate);
            foreach (var pair in d3)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

        }

        private int MyPredicate(KeyValuePair<string, int> arg)
        {
            return arg.Value;
        }
    }
}
