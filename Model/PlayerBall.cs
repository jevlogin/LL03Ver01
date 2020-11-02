using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerBall : PlayerBase
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