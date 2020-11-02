using UnityEngine;


namespace JevLogin
{
    public sealed class CameraController : IExecute
    {
        #region Fields

        private Transform _player;
        private Transform _cameraMain;
        private Vector3 _offset;

        #endregion


        #region Properties

        public CameraController(Transform player, Transform cameraMain)
        {
            _player = player;
            _cameraMain = cameraMain;
            _cameraMain.LookAt(_player);
            _offset = _cameraMain.position - _player.position;
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            _cameraMain.position = _player.position + _offset;
        }

        #endregion
    }
}
