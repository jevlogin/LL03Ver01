using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerBall : PlayerBase
    {
        #region Fields

        private Rigidbody _rigidbody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }

        #endregion
    }
}