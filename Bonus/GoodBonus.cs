using JevLogin;
using UnityEngine;


public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
{
    #region Fields

    private Material _material;

    private float _lengthFlay;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _lengthFlay = Random.Range(1.0f, 5.0f);
        Flicker();
    }

    #endregion


    #region Methods

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
    }

    public void Flicker()
    {
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
    }

    protected override void Interaction()
    {
        //TODO Add bonus
    } 

    #endregion
}
