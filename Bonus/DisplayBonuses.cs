using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayBonuses
    {
        #region Fields

        private Text _text;

        #endregion


        #region Methods

        public DisplayBonuses()
        {
            //  будем грузить из кода. не знаю что 
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }

        #endregion
    }
}
