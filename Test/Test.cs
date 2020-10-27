using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var objects = FindObjectsOfType<GoodBonus>().ToList();
            var bonus = GameObject.Find("InteractiveCube").GetComponent<GoodBonus>();
            objects.Remove(bonus);
            print($"{objects.Contains(bonus)}");
        }
    }
}
