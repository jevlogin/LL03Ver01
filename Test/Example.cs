using UnityEngine;


namespace JevLogin
{
    public sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            ExampleEvent exampleEvent = new ExampleEvent();
            exampleEvent.Test += () => { Debug.Log(121); };

            exampleEvent.StartMethod();

            return;
            //ExampleDelegate exampleDelegate = new ExampleDelegate();

            ////exampleDelegate.Test();
            ////exampleDelegate.StartDelegate();
            ////exampleDelegate.RemoveDelegate(() => Debug.Log($"JEVLOGIN"));
            ////exampleDelegate.StartDelegate();

            //exampleDelegate.NameMethod("Attack");

        }
    }
}