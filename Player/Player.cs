using UnityEngine;


namespace JevLogin
{
    public class Player : MonoBehaviour, IInit
    {
        #region Fields

        private Rigidbody _rigidbody;

        public float Speed = 3.0f;

        public float JumpHeight = 7.0f;
        public float MinDownRayCast = 0.15f;

        private bool _isGround;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            _rigidbody.velocity = movement * Speed * Time.deltaTime;
        }

        protected void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
            }
        }

        public void Init()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
