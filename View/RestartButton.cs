using System;
using UnityEngine;


namespace JevLogin
{
    public class RestartButton : InteractiveObject
    {
        public event Action OnRestartButton = delegate () { };


        public override void Execute()
        {
            
        }

        protected override void Interaction()
        {
            OnRestartButton.Invoke();
        }
    }
}