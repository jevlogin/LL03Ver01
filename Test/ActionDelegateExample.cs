using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public enum UserAction : byte
    {
        None    = 0,
        Up      = 1,
        Down    = 2
    }

    public sealed class ActionDelegateExample
    {
        private readonly Dictionary<UserAction, Action> _actions;

        public ActionDelegateExample()
        {
            _actions = new Dictionary<UserAction, Action>
            {
                [UserAction.Up] = UpMethod,
                [UserAction.Down] = DownMethod
            };
        }

        public Action this[UserAction index] => _actions[index];

        private void DownMethod()
        {
            Debug.Log($"{nameof(DownMethod)}");
        }

        private void UpMethod()
        {
            Debug.Log($"{nameof(UpMethod)}");
        }
    }
}
