using UnityEngine;


namespace JevLogin
{
    public class Enemy : IPlayer, IUser
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Example
    {
        private void Main()
        {
            Enemy enemy = new Enemy();
            ((IPlayer)enemy).Move();
            ((IUser)enemy).Move();

            enemy.Move();
        }
    }
}
