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

        public void GameOver(object sender, CaughtPlayerEventArgs args)
        {
            var text = $"Вы проиграли! Вас убил {((InteractiveObject)sender).gameObject.name} - {args.Color} цвета";
            _finishGameLabel.text = text;
        }
    }
}
