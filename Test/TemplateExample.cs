using UnityEngine;


namespace JevLogin
{
    public sealed class TemplateExample : MonoBehaviour
    {
        private void Start()
        {
            Display(5);
            Display(5.0f);
            Display(5d);
            Display("mama");
        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }
    }
}
