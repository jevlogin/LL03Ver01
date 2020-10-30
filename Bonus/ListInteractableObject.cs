using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        #region Fields

        private InteractiveObject[] _interactiveObjects;
        private InteractiveObject _current;

        private int _index = -1;

        #endregion


        #region Property

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            System.Array.Sort(_interactiveObjects);
        }

        public object Current => _interactiveObjects[_index];

        public int Count => _interactiveObjects.Length;

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        #endregion


        #region Method


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

        public void Reset() => _index = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
