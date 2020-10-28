using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var objects = new ListInteractableObject();

            for (int i = 0; i < objects.Count; i++)
            {
                print($"{objects[i]}");
            }

        }
    }
}
