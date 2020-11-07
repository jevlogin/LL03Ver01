using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private Text _finishGameLabel;

        #endregion


        #region Methods

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = string.Empty;
            _finishGameLabel.color = Color.red;
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли! Вас убил {name} {ColorManager.ColorName[color]} цвета";
        }

        #endregion
    }
}
