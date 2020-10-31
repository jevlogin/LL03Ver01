using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public class ExampleDelegate
    {
        private MyDelegate _myDelegate;

        private Action<int> _action;
        private Func<int, int> _func;
        private Predicate<int> _predicate;

        public ExampleDelegate()
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

        private Dictionary<string, Action> _actions;


        public void NameMethod(string value)
        {
            _actions = new Dictionary<string, Action>
            {
                ["Move"] = Move,
                ["Attack"] = Attack
            };
            var beginInvoke = _actions[value].BeginInvoke(CallBack, value);

            if (beginInvoke.IsCompleted)
            {

            }

            _actions[value].EndInvoke(beginInvoke); //  Асинхронный метод


            //_actions[value].Invoke();   //  Синхронный метод

            //  Dictionary заменяет весь switch
            
        }

        private void CallBack(IAsyncResult ar)
        {
            Debug.Log($"CallBack");
        }

        private void Attack()
        {
            Debug.Log($"Attack");
        }

        private void Move()
        {
            Debug.Log($"Move");
        }
    }
}