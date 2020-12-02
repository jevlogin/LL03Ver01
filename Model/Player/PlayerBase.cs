using UnityEngine;


namespace JevLogin
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Fields
        
        [Space(10)]
        [Range(5, 30)]
        public float Speed = 3.0f;

        #endregion


        #region Methods
        
        public abstract void Move(float x, float y, float z);

        #endregion
    }
}
