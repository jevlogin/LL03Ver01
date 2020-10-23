using UnityEngine;


public class InteractiveObject
{
    public virtual string DisplayFirstWay()
    {
        return $"I am a {nameof(InteractiveObject)} class method";
    }

    public virtual string DisplaySecondWay()
    {
        return $"I am a {nameof(InteractiveObject)} class method";
    }
    
    public virtual string DisplayThirdWay()
    {
        return $"I am a {nameof(InteractiveObject)} class method";
    }
}
