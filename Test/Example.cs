using UnityEngine;


namespace JevLogin
{
    public sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var addComponent = TestCube.CreateTestCube(100);
            addComponent.OnTriggerChange += i => { Debug.Log(i); };

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