using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class TestCube : MonoBehaviour
    {
        private int _healthPoint;
        public event Action<int> OnTriggerChange = delegate(int i) { }; //  подписались пустым делегатом

        public static TestCube CreateTestCube(int hp)
        {
            var result = new GameObject(nameof(TestCube)).AddComponent<TestCube>();
            result._healthPoint = hp;
            result.gameObject.AddComponent<BoxCollider>().isTrigger = true;
            result.gameObject.AddComponent<Rigidbody>().useGravity = false;

            return result;

        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerChange?.Invoke(_healthPoint--);
        }
    }
}
