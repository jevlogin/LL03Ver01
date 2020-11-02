using System;
using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        #region Fields

        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        private float _lengthFlay;
        private float _speedRotation;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Flay();
            Rotation();
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        #endregion
    }
}
