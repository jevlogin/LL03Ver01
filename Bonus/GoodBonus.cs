using System;
using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        #region Fields

        public event Action<int> OnPointChange = delegate (int i) { };

        public int Point;

        private Material _material;

        private float _lengthFlay;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Flay();
            Flicker();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }

        #endregion
    }
}
