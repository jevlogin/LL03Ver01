using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var objects = FindObjectsOfType<GoodBonus>().Distinct(new GoodBonusEqualityComparer());

            foreach (var o in objects)
            {
                print($"{o.name}");
            }
        }
    }
}
