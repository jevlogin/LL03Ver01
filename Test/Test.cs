using System;
using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var example = new ActionDelegateExample();
            example[UserAction.Up]();
            example[UserAction.Down]();
        }
    }
}
