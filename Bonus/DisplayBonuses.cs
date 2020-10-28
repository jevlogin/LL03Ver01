using UnityEngine;
using UnityEngine.UI;

namespace JevLogin
{
    public sealed class DisplayBonuses
    {
        private Text _text;
        private static int _currentBonus = 0;

        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _currentBonus += value;
            _text.text = $"Вы набрали {_currentBonus}";
        }
    }
}
