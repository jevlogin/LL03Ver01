using UnityEngine;


namespace JevLogin
{
    public class Player : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public float Speed = 3.0f;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * Speed);
        }
    }
}
