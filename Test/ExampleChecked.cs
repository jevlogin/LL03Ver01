using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleChecked : MonoBehaviour
    {
        private void Start()
        {
            int a = 150;
            int b = 150;

            try
            {
                byte result = checked((byte)(a + b));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
