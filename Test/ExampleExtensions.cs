using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JevLogin
{
    public static class ExampleExtensions
    {
        public static bool IsOneOf<T>(this T self, params T[] elem)
        {
            return elem.Contains(self);
        }

        public static bool TryBool(this string self)
        {
            return bool.TryParse(self, out var res) && (res || !res);
        }

        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
    }
}

