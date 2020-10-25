using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyHead : MonoBehaviour, IDamagable, ILoggerSecond
    {
        public void AddDamage()
        {
            Debug.Log($"{name} damage");
        }

        public void Log()
        {
            Debug.Log($"HeadShoot {name}");
        }
    }
}
