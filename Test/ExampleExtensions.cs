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
        public static Color SetColorAlpha(this Color c, float alpha)
        {
            return new Color(c.r, c.g, c.b, alpha);
        }

        public static List<T> GetAll<T>(this Transform obj)
        {
            var results = new List<T>();
            obj.GetComponentsInChildren(results);
            return results;
        }

        public static Transform FindDeep(this Transform obj, string id)
        {
            if (obj.name == id)
            {
                return obj;
            }

            var count = obj.childCount;
            for (int i = 0; i < count; i++)
            {
                var posObj = obj.GetChild(i).FindDeep(id);
                if (posObj != null)
                {
                    return posObj;
                }
            }

            return null;
        }

        public static T[] Increase<T>(this T[] values, int increment)
        {
            T[] array = new T[values.Length + increment];
            values.CopyTo(array, 0);
            return array;
        }

        public static Vector3 MultiplyX(this Vector3 vector, float value)
        {
            vector = new Vector3(value * vector.x, vector.y, vector.z);
            return vector;
        }
        public static Vector3 MultiplyY(this Vector3 vector, float value)
        {
            vector = new Vector3(vector.x, value * vector.y, vector.z);
            return vector;
        }
        public static Vector3 MultiplyZ(this Vector3 vector, float value)
        {
            vector = new Vector3(vector.x, vector.y, value * vector.z);
            return vector;
        }

        public static float GetRandom(this Vector2 vector)
        {
            return UnityEngine.Random.Range(vector.x, vector.y);
        }

        public static T ReturnRandom<T>(this List<T> list)
        {
            var value = list[UnityEngine.Random.Range(0, list.Count)];
            return value;
        }

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

        public static float TrySingle(this string self)
        {
            if (Single.TryParse(self, out var result))
            {
                return result;
            }
            return 0.0f;
        }

        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
    }
}

