using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleTuple : MonoBehaviour
    {
        private int _maxHP;
        private int _currentHP;

        public (int currentHP, int maxHP) GetHP()
        {
            return (_currentHP, _maxHP);
        }

        private void Start()
        {
            (int currentHP, int maxHP) playerHp = (42, 100);
            Debug.Log($"{playerHp.currentHP}/{playerHp.maxHP}");
        }
    }
}
