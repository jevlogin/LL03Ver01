using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace JevLogin
{
    public static class ExampleExtensions
    {
        public static T ReturnRandom<T>(this List<T> list, T[] itemToExclude)
        {
            var value = list[UnityEngine.Random.Range(0, list.Count)];

            while (itemToExclude.Contains(value))
            {
                value = list[UnityEngine.Random.Range(0, list.Count)];
            }

            return value;
        }

        public static int ReturnNearestIndex(this Vector3[] nodes, Vector3 destionation)
        {
            var nearestDistance = Mathf.Infinity;
            var index = 0;
            var length = nodes.Length;
            for (var i = 0; i < length; i++)
            {
                var distanceToNode = (destionation + nodes[i]).sqrMagnitude;
                if (!(nearestDistance > distanceToNode))
                {
                    continue;
                }
                nearestDistance = distanceToNode;
                index = i;
            }
            return index;
        }

        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }
            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T[] Concat<T>(this T[] x, T[] y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var oldLen = x.Length;
            Array.Resize(ref x, x.Length + y.Length);
            Array.Copy(y, 0, x, oldLen, y.Length);
            return x;
        }

        public static T GetOrAddComponent<T>(this GameObject child) where T : Component
        {
            var result = child.GetComponent<T>();
            if (!result)
            {
                result = child.AddComponent<T>();
            }
            return result;
        }

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

