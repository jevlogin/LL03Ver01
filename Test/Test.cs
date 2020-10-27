using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var goodBonusComparer = new GoodBonusComparer();
            var objects = FindObjectsOfType<GoodBonus>().ToList();
            objects.Sort(goodBonusComparer);
            foreach (var goodBonus in objects)
            {
                print($"{goodBonus.name} - {goodBonus.Point}");
            }
        }
    }
}
