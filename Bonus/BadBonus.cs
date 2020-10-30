using System;
using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation, ICloneable
    {
        private float _lengthFlay;
        private float _speedRotation;

        public delegate void CaughPlayerChange();
        public CaughPlayerChange CaughPlayer;

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        protected override void Interaction()
        {
            CaughPlayer();
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }
    }
}
