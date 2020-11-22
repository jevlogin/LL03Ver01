using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Random;


namespace JevLogin
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        #region Fields

        protected Color _color;
        private bool _isInteractable;

        [SerializeField] private bool _isAllowScalling;
        [SerializeField] private float _activeDistance;

        #endregion


        #region Properties

        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                if (TryGetComponent<Renderer>(out var renderer))
                {
                    renderer.enabled = _isInteractable;
                }
                if (TryGetComponent<Collider>(out var collider))
                {
                    collider.enabled = _isInteractable;
                }
            }
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            IsInteractable = true;

            _color = ColorManager.GetValue(Range(0, 9));

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

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "MiniMapBorder.png", _isAllowScalling);
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Transform t = transform;
            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            var flat = new Vector3(_activeDistance, 0, _activeDistance);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5.0f);
#endif
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
