using UnityEngine;

namespace JevLogin
{
    public sealed class ExampleClass : MonoBehaviour
    {
        private void Start()
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Renderer rend = go.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load("glass") as Texture;
        }
    }
}
