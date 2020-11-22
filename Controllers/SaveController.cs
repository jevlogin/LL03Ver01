using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class SaveController
    {
        public List<object> ListObjects;

        public SaveController()
        {
            ListObjects = new List<object>();
        }

        public SaveController(PlayerBase player)
        {
            ListObjects = new List<object>();
            ListObjects.Add(player);
        }

    }
}
