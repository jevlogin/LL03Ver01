using UnityEngine;


namespace JevLogin
{
    public class Enemy : IPlayer, IUser
    {
        void IPlayer.Move()
        {
            throw new System.NotImplementedException();
        }

        void IUser.Move()
        {
            throw new System.NotImplementedException();
        }

    }
}
