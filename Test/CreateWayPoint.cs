using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class CreateWayPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private PathBot _rootWaypoint;

        public void InstantiateObj(Vector3 pos)
        {
            if (!_rootWaypoint)
            {
                _rootWaypoint = new GameObject("Waypoint").AddComponent<PathBot>();
            }

            if (_prefab != null)
            {
                Instantiate(_prefab, pos, Quaternion.identity, _rootWaypoint.transform);
            }
            else
            {
                throw new System.Exception($"Нет префаба на компоненте {typeof(CreateWayPoint)} {gameObject.name}");
            }
        }
    }
}
