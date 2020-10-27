using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var interactiveObject = new ListInteractableObject();

            foreach (var o in interactiveObject)
            {
                print(o);
            }
        }
    }
}
