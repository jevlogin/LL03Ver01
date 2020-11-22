using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JevLogin
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        public PlayerType PlayerType = PlayerType.Ball;
        public int CountEnemy = 3;

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private SaveController _saveController;
        private SaveDataRepository _saveDataRepository;

        private int _countBonuses = 0;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            new GameInitializator();

            _interactiveObject = new ListExecuteObject();
            _saveDataRepository = new SaveDataRepository();
            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
                _saveController = new SaveController(player);
            }

            _cameraController = new CameraController(player.transform, _reference.CameraMain.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player, _saveController, _saveDataRepository);
                _interactiveObject.AddExecuteObject(_inputController);
            }


            if (_reference.Ghost)
            {
                _interactiveObject.AddExecuteObject(_reference.Ghost);
            }


            for (int i = 0; i < CountEnemy; i++)
            {
                var tp = _reference.Ghost.GeneratePoint();
                var ghost = Instantiate(_reference.Ghost, tp, Quaternion.identity);
                _interactiveObject.AddExecuteObject(ghost);
            }

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            foreach (var soloObject in _interactiveObject)
            {
                if (soloObject is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;

                    _saveController.ListObjects.Add(badBonus);
                    //badBonus.AddTo(_saveController.ListObjects);
                }

                if (soloObject is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;

                    _saveController.ListObjects.Add(goodBonus);
                    //goodBonus.AddTo(_saveController.ListObjects);
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }


        private void Update()
        {
            if (_interactiveObject == null)
            {
                return;
            }
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

        private void RestartGame()
        {
            _reference.RestartButton.onClick.RemoveAllListeners();
            Dispose();
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        private void CaughtPlayer(string value, Color arg)
        {
            _reference.RestartButton.gameObject.SetActive(true);
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