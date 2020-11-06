using UnityEngine;
using UnityEngine.UI;

namespace JevLogin
{
    public class Reference
    {
        #region Fields

        private PlayerBall _playerBall;
        private Camera _cameraMain;
        private Canvas _canvas;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Button _restartButton;
        private Ghost _ghost;

        #endregion


        #region Properties

        public Ghost Ghost
        {
            get
            {
                if (_ghost == null)
                {
                    var ghost = Resources.Load<Ghost>("Ghost");
                    _ghost = new Ghost(ghost);
                }
                return _ghost;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var restartButton = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(restartButton, Canvas.transform);
                }
                return _restartButton;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var bonuseObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(bonuseObject, Canvas.transform);
                }
                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var endObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(endObject, Canvas.transform);
                }
                return _endGame;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var playerObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(playerObject);
                }
                return _playerBall;
            }
        }

        public Camera CameraMain
        {
            get
            {
                if (_cameraMain == null)
                {
                    _cameraMain = Camera.main;
                }
                return _cameraMain;
            }
        }

        #endregion
    }
}
