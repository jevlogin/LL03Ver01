using UnityEngine;


public abstract class InteractiveObject : MonoBehaviour
{
    protected abstract void Interaction();

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
