using System;
using UnityEngine;


namespace JevLogin
{
    public class Example
    {
        private MyDelegate _myDelegate;

        private Action<int> _action;
        private Func<int, int> _func;
        private Predicate<int> _predicate;

        public Example()
        {
            _action = Action;
            _func = Func;
            _predicate = Predicate;
        }

        private void Action(int obj)
        {
            throw new NotImplementedException();
        }
        private bool Predicate(int obj)
        {
            throw new NotImplementedException();
        }

        private int Func(int arg)
        {
            throw new NotImplementedException();
        }

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