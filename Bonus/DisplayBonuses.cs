using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayBonuses
    {
        private Text _text;

        public DisplayBonuses()
        {
            //  будем грузить из кода. не знаю что 
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }
    }
}
