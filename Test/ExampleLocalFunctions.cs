using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleLocalFunctions : MonoBehaviour
    {
        private void GetAge()
        {
            var ageInput = "17";

            if (!IsAdult(ageInput))
            {
                Debug.Log("Регистрация разрешена только совершеннолетним");
            }

            bool IsAdult(string value)
            {
                if (!Int32.TryParse(value, out var age))
                {
                    throw new Exception(@"Возраст введен некорретно");
                }
                if (age > 18)
                {
                    return true;
                }
                return false;
            }
        }

        
    }
}
