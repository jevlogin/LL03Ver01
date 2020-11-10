using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Lesson05Task03 : MonoBehaviour
    {
        [SerializeField] private List<int> _vsInt = new List<int>() { 1, 2, 1, 4, 1, 4, 6, 3, 8, 2, 8, 6 };

        [SerializeField] private List<object> tObjects = new List<object>() { 0, 1, "текст 1", 0, 2, 3, 3.4, 4, 3, 1, 9, 3.4, "1" };

        private void Start()
        {
            GetCountHowTimesEachElement1(_vsInt);
            Debug.Log("#################################");

            GetCountHowTimesEachElement2(_vsInt);
            Debug.Log("#################################");

            GetCountHowTimesEachElement3(tObjects);
        }

        private void GetCountHowTimesEachElement3<T>(List<T> tObjects)
        {
            foreach (var item in tObjects.Distinct())
            {
                Debug.Log($"{item} встречается {tObjects.Where(count => count.Equals(item)).Count()} раз");
            }

        }

        private void GetCountHowTimesEachElement2(List<int> vsInt)
        {
            foreach (var item in vsInt.Distinct())
            {
                Debug.Log($"{item} встречается {vsInt.Where(count => count == item).Count()} раз");
            }
        }

        private void GetCountHowTimesEachElement1(List<int> vs)
        {
            var count = 0;
            List<int> key = new List<int>();
            vs.Sort();

            for (int i = 0; i < vs.Count; i++)
            {
                if (!key.Contains(vs[i]))
                {
                    key.Add(vs[i]);
                }
                else
                {
                    continue;
                }

                for (int k = 0; k < vs.Count; k++)
                {
                    if (vs[i].Equals(vs[k]))
                    {
                        count++;
                    }
                }

                Debug.Log($"{vs[i]} встречается {count} раз.");
                count = 0;
            }
        }
    }
}
