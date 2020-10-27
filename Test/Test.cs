using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var a = FindObjectOfType<BadBonus>().Clone();
        }
    }
}
