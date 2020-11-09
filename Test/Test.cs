using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            User user = new User();

            foreach (string name in user.UserName)
            {
                Debug.Log(name);
            }
        }

    }

    internal class User
    {
        private string[] Names =
        {
            "Roman",
            "Ilya",
            "Igor",
            "Lera"
        };

        public IEnumerable<string> UserName 
        { 
            get
            {
                for (int i = 0; i < Names.Length; i++)
                {
                    yield return Names[i];
                }
            }
        }
    }
}
