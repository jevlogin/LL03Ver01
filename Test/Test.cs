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
            DelegateObserver.Source s = new DelegateObserver.Source();
            DelegateObserver.Observer1 o1 = new DelegateObserver.Observer1();
            DelegateObserver.Observer2 o2 = new DelegateObserver.Observer2();
            DelegateObserver.MyDelegate d1 = new DelegateObserver.MyDelegate(o1.Do);
            
            s.Add(d1);
            s.Add(o2.Do);
            s.Run();
            s.Remove(o1.Do);
            s.Run();
        }
    }
}
