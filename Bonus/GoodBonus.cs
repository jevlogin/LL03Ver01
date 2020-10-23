using UnityEngine;


public sealed class GoodBonus : InteractiveObject
{
    public override string DisplaySecondWay()
    {
        return $"I am a {nameof(GoodBonus)} class method";
    }

    public new string DisplayThirdWay()
    {
        return $"I am a {nameof(GoodBonus)} class method";
    }
}
