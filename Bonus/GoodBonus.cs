using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker, IEquatable<GoodBonus>
    {
        #region Fields

        public int Point;

        private Material _material;
        private DisplayBonuses _displayBonuses;

        private float _lengthFlay;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
            _lengthFlay = UnityEngine.Random.Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(Point);
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }

        #endregion
    } 
}
