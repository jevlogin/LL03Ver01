using UnityEngine;


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

        #endregion


        #region Properties

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
