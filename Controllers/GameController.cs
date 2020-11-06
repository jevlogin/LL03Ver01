using Boo.Lang;
using System;
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
        private List<Ghost> _ghostsList;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private GenerateVectorController _generateVectorController;

        private int _countBonuses = 0;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            _generateVectorController = new GenerateVectorController();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, _reference.CameraMain.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
            }

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            for (int i = 0; i < CountEnemy; i++)
            {
                if (_ghostsList == null)
                {
                    _ghostsList = new List<Ghost>();
                }

                var ghost = new Ghost(_reference.Ghost);

                _ghostsList.Add(ghost);
            }

            foreach (var item in _ghostsList)
            {
                if (item is IExecute execute)
                {
                    _interactiveObject.AddExecuteObject(item);
                    print($"Добавили призрака в список обновляемых объектов {item}");
                }
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

                if (soloObject is Ghost ghost)
                {
                    //TODO подписка насобытия для призраков
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