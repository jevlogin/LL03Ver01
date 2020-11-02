using System.Drawing;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private Text _finishGameLabel;

        #endregion


        #region Methods

        public DisplayEndGame()
        {
            // будем грузить из кода
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли! Вас убил {name} {color} цвета";
        }

        #endregion
    }
}
