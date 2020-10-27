using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var interactiveObject = new ListInteractableObject();

            while (interactiveObject.MoveNext())
            {
                print(interactiveObject.Current);
            }
        }
    }
}
