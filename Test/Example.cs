using UnityEngine;


namespace JevLogin
{
    public class Example
    {
        private MyDelegate _myDelegate;

        public void Test()
        {
            _myDelegate += MyDelegate;  //  Стандартный вызов
            _myDelegate += () => Debug.Log($"2");   //  лямбда выражение
            _myDelegate += delegate { Debug.Log(3); };   //  Анонимный метод
        }

        public void StartDelegate()
        {
            _myDelegate?.Invoke();
        }

        public void RemoveDelegate(MyDelegate myDelegate)
        {
            _myDelegate -= MyDelegate;
            _myDelegate += myDelegate;
        }

        private void MyDelegate()
        {
            Debug.Log($"1");
        }
    }
}