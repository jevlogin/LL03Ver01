using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class SaveController
    {
        public List<object> _listObjects;

        public SaveController(PlayerBase player)
        {
            _listObjects = new List<object>();
            _listObjects.Add(player);
        }

    }
}
