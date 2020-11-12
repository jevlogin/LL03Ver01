using JevLogin;
using UnityEngine;


public sealed class InputController : IExecute
{
    #region Fields

    private readonly PlayerBase _playerBase;
    private readonly SaveDataRepository _saveDataRepository;
    private readonly KeyCode _savePlayer = KeyCode.C;
    private readonly KeyCode _loadPlayer = KeyCode.V;

    #endregion


    #region Properties

    public InputController(PlayerBase player)
    {
        _playerBase = player;
        _saveDataRepository = new SaveDataRepository();
    }

    #endregion


    #region IExecute

    public void Execute()
    {
        _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, Input.GetAxis(AxisManager.VERTICAL));

        if (Input.GetKeyDown(_savePlayer))
        {
            _saveDataRepository.Save(_playerBase);
        }

        if (Input.GetKeyDown(_loadPlayer))
        {
            _saveDataRepository.Load(_playerBase);
        }
    }

    #endregion
}
