using System;
using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private float _lengthFlay;
        private float _speedRotation;

        public delegate void CaughPlayerChange(object value);
        private event CaughPlayerChange _caughPlayer;
        //  Полная реализация события
        public event CaughPlayerChange CaughPlayer
        {
            add { _caughPlayer += value; }
            remove { _caughPlayer -= value; }
        }

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
            _caughPlayer?.Invoke(this);
        }
    }
}
