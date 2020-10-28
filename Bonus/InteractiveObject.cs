using JevLogin;
using System;
using UnityEngine;


public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
{
    public bool IsInteractable
    {
        get;
    } = true;

    private void Start()
    {
        ((IAction)this).Action();
        ((IInitialization)this).Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractable || !other.CompareTag("Player"))
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Поздравляю! Вы нашли бонус!");
        }
        else
        {
            Debug.Log($"Хрен там было");
        }
        Interaction();
        Destroy(gameObject);
    }

    protected abstract void Interaction();

    void IAction.Action()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }

    void IInitialization.Action()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Color.cyan;
        }
    }

    public int CompareTo(InteractiveObject other)
    {
        return name.CompareTo(other.name);
    }
}
