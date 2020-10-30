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
            var example = FindObjectOfType<PredicateAndFuncDelegateExample>();

            example.Predicate = collision => collision.gameObject.CompareTag("Player");

            const float damage = 5.0f;

            example.Func = f => f - damage;
        }
    }
}
