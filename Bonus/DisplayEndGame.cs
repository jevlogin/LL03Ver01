using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = string.Empty;
        }

        public void GameOver(object o, CaughtPlayerEventArgs args)
        {
            var text = $"Вы проиграли! Вас убил {o.GetType().Name} - {args.Color} цвета";
            _finishGameLabel.text = text;
        }
    }
}
