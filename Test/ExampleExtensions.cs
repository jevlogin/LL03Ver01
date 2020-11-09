using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JevLogin
{
    public static class ExampleExtensions
    {


        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
    }
}

