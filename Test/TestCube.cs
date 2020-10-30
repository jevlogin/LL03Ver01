using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class TestCube : MonoBehaviour
    {
        private int _healthPoint;
        public event Action<Data> OnTriggerChange = delegate (Data i) { }; //  подписались пустым делегатом

        public static TestCube CreateTestCube(int hp)
        {
            var result = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<TestCube>();
            result.name = nameof(TestCube);
            result._healthPoint = hp;
            result.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            result.gameObject.AddComponent<Rigidbody>().useGravity = false;

            return result;
        }

        public struct Data
        {
            public int Damage;
            public string Name;

            public override string ToString()
            {
                return $"Name = {Name}, Damage = {Damage}";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerChange?.Invoke(new Data
            {
                Damage = _healthPoint--,
                Name = name
            });
        }
    }
}
