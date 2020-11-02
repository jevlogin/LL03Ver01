using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        public PlayerType PlayerType = PlayerType.Ball;

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;

        private int _countBonuses;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            var reference = new Reference();
            
            _interactiveObject = new ListExecuteObject();

            _displayEndGame = new DisplayEndGame(reference.EndGame);
            _displayEndGame = new DisplayEndGame(reference.Bonuse);

            PlayerBase player = null;

            if (PlayerType == PlayerType.Ball)
            {
                player = reference.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, reference.CameraMain.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
            }

            foreach (var soloObject in _interactiveObject)
            {
                if (soloObject is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (soloObject is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                }
            }
        }



        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion


        #region Methods

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        private void CaughtPlayer(string value, Color arg)
        {
            Time.timeScale = 0.0f;
        }

        public void Dispose()
        {
            foreach (var soloObject in _interactiveObject)
            {
                if (soloObject is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (soloObject is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }

        #endregion
    }
}