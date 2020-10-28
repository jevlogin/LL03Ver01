using JevLogin;
using UnityEngine;


public sealed class CheckBonus : InteractiveObject
{
    private static int? _checkBonus;

    private void Awake()
    {
        Debug.Log($"{_checkBonus}");
        if (_checkBonus == null)
        {
            _checkBonus = 0;
        }
        Debug.Log($"{_checkBonus}");
    }
    protected override void Interaction()
    {

    }
}
