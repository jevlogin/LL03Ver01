using JevLogin;
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
{
    public bool IsInteractable { get; } = true;
    protected Color _color;

    private void Start()
    {
        Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractable || !other.CompareTag("Player"))
        {
            return;
        }

        Interaction();
        Destroy(gameObject);
    }

    protected abstract void Interaction();

    public int CompareTo(InteractiveObject other)
    {
        return name.CompareTo(other.name);
    }

    public void Action()
    {
        _color = Random.ColorHSV();
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = _color;
        }
    }
}
