using UnityEngine;


namespace JevLogin
{
    public sealed class TemplateExample : MonoBehaviour
    {
        private void Start()
        {
            var player = FactoryEnemy<Player, float>(777.0f);
            Display($"Speed = {player.Speed}");
        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }

        private T FactoryEnemy<T, T2>(T2 hp) where T : IInit<T2>, new ()
            where T2 : struct
        {
            var player = new T();
            player.Init(hp);
            return player;
        }
    }
}
