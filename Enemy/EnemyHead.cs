using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyHead : MonoBehaviour, IDamagable
    {
        public void AddDamage()
        {
            Debug.Log($"{name} damage");
        }
    }
}
