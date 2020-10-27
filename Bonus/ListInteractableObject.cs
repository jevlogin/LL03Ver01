using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class ListInteractableObject : IEnumerator
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public object Current => _interactiveObjects[_index];

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
