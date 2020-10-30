using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            int x = 1;
            int y = 0;
            try
            {
                int result = x / y;
            }
            catch (Exception ex) when (y == 0)
            {
                Debug.LogError($"y не должен быть равен нулю");
            }
            catch(Exception ex)
            {
                Debug.LogError($"{ex.Message}");
            }
        }

    }
}
