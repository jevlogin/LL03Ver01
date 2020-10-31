using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class PredicateAndFuncDelegateExample : MonoBehaviour
    {
        public Predicate<Collision> Predicate;
        public Func<float, float> Func;
        private float _armor = 3.0f;
        private float _healthPoint = 100.0f;

        private void OnCollisionEnter(Collision collision)
        {
            if (Predicate(collision))
            {
                _healthPoint = Func(_healthPoint);
            }
            Debug.Log($"{_healthPoint}");
        }
    }
}
