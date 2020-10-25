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

            var player = FactoryEnemy<Player>();
            player.JumpHeight = 5.0f;

        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }

        private T FactoryEnemy<T>() where T : IInit, new ()
        {
            var player = new T();
            player.Init();
            return player;
        }
    }
}
