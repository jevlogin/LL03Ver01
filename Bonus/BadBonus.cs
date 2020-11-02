using System;
using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }
        
        protected override void Interaction()
        {
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public override void Execute()
        {
        }
    }
}
