using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {

            InteractiveObject interactiveObject = new InteractiveObject();
            Debug.Log(interactiveObject.DisplayFirstWay());
            Debug.Log(interactiveObject.DisplaySecondWay());
            Debug.Log(interactiveObject.DisplayThirdWay());

            Debug.Log("++++++++++++++++++++++++++++++");

            InteractiveObject interactiveObject1 = new GoodBonus();
            Debug.Log(interactiveObject1.DisplayFirstWay());
            Debug.Log(interactiveObject1.DisplaySecondWay());
            Debug.Log(interactiveObject1.DisplayThirdWay());

            Debug.Log("++++++++++++++++++++++++++++++");

            GoodBonus interactiveObject2 = new GoodBonus();
            Debug.Log(interactiveObject2.DisplayFirstWay());
            Debug.Log(interactiveObject2.DisplaySecondWay());
            Debug.Log(interactiveObject2.DisplayThirdWay());

            Debug.Log("++++++++++++++++++++++++++++++");


            //Player player = new PlayerBall();

            /**
            Vector v1 = new Vector(-5, 5);

            Vector v2 = (Vector)10;

            Vector v3 = v1 + v2;

            Debug.Log($"v1.x = {v1.X} v1.y={v1.Y}");
            Debug.Log($"(v1 + v2):{v3}");
            Debug.Log($"-(v1+v2):{-v3}");
            */
        }
    }
}
