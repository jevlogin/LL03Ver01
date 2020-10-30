using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyBody : MonoBehaviour, IDamagable
    {
        public void AddDamage()
        {
            Debug.Log($"{name} damage");
        }
    } 
}
