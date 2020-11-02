using UnityEngine;
using static UnityEngine.Random;


namespace JevLogin
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        #region Fields

        protected Color _color;
        private bool _isInteractable; 

        #endregion


        #region Properties

        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            IsInteractable = true;
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }

            Interaction();
            IsInteractable = false;
        }

        #endregion


        #region Methods

        protected abstract void Interaction(); 

        #endregion


        #region IExecuteMethods

        public abstract void Execute();

        #endregion
    } 
}
