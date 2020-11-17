using JevLogin;
using UnityEngine;


public sealed class InputController : IExecute
{
    #region Fields

    private readonly PlayerBase _playerBase;
    private readonly SaveDataRepository _saveDataRepository;
    private readonly SaveController _saveController;

    private readonly KeyCode _savePlayer = KeyCode.C;
    private readonly KeyCode _saveAll = KeyCode.Y;
    private readonly KeyCode _loadAll = KeyCode.U;
    private readonly KeyCode _loadPlayer = KeyCode.V;

    #endregion


    #region Properties

    public InputController(PlayerBase player, SaveController saveController, SaveDataRepository saveDataRepository)
    {
        _saveDataRepository = saveDataRepository;
        _playerBase = player;
        _saveController = saveController;
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

        if (Input.GetKeyDown(_saveAll))
        {
            _saveDataRepository.Save(_saveController._listObjects);
        }

        if (Input.GetKeyDown(_loadAll))
        {
            _saveDataRepository.Load(_saveController._listObjects);
        }

        if (Input.GetKeyDown(_loadPlayer))
        {
            _saveDataRepository.Load(_playerBase);
        }
    }

    #endregion
}
