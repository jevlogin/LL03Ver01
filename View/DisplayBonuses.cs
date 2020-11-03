using System;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayBonuses
    {
        #region Fields

        private Text _bonuseLable;

        #endregion


        #region Methods

        public DisplayBonuses(GameObject bonus)
        {
            _bonuseLable = bonus.GetComponentInChildren<Text>();
            _bonuseLable.text = string.Empty;
        }

        public void Display(int value)
        {
            _bonuseLable.text = $"Вы набрали {value}";
        }

        #endregion
    }
}
