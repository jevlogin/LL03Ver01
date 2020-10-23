using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerBall : Player
    {
        private void Update()
        {
            Jump();
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}