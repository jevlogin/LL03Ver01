using UnityEngine;


namespace JevLogin
{
    public sealed class TemplateExample : MonoBehaviour
    {
        private void Start()
        {
            //Display(5);
            //Display(5.0f);
            //Display(5d);
            //Display("mama");

            var player = FactoryEnemy<Player, float>(777.0f);
            Display($"Speed = {player.Speed}");

        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }

        private T FactoryEnemy<T, T2>(T2 hp) where T : IInit<T2>, new ()
        {
            var player = new T();
            player.Init(hp);
            return player;
        }
    }
}
