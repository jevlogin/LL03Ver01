using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                int x = int.Parse("-3");
                if (x < 0)
                {
                    throw new MyException("Введено недопостимое значение", x);
                    Debug.Log("OK");
                }
            }
            catch (MyException e)
            {
                Debug.Log($"{e.Message} {e.Value}");
            }
        }

    }
}
