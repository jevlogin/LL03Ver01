using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleTuple : MonoBehaviour
    {
        private sealed class Player
        {
            private int _maxHP;
            private int _currentHP;

            public Player()
            {
                _maxHP = 100;
                _currentHP = 42;
            }

            public (int currentHP, int maxHP) GetHP()
            {
                return (_currentHP, _maxHP);
            }
        }

        private void Start()
        {
            Player player = new Player();

            (int currentHP, int maxHP) playerHp = player.GetHP();
            Debug.Log($"{playerHp.currentHP}/{playerHp.maxHP}");

            var playerHp2 = new Tuple<int, int>(42, 100);
            Debug.Log($"{playerHp2.Item1}/{playerHp2.Item2}");
        }
    }
}
