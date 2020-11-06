using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace JevLogin
{
    public class Ghost : InteractiveObject
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Vector3[] _waypoints;

        private int _currentWaypointIndex;

        [SerializeField] private Vector4 _sizeOfPlatform;
        [SerializeField] private Transform _transformGround;
        [SerializeField] private GameObject _prefab;

        private void Awake()
        {
            if (_transformGround == null)
            {
                _transformGround = GameObject.FindGameObjectWithTag("Ground").transform;
            }
            GenerateVector4ToGameObject();
        }

        private void Start()
        {
            if (_navMeshAgent == null)
            {
                _navMeshAgent = GetComponent<NavMeshAgent>();
                _navMeshAgent.autoRepath = true;

            }

            GenerateWaypoints();

            _navMeshAgent.SetDestination(_waypoints[0]);

        }

        private void GenerateWaypoints()
        {
            if (_waypoints == null || _waypoints.Length == 0)
            {
                _waypoints = new[] { GeneratePoint() };
            }

            Array.Resize(ref _waypoints, _waypoints.Length + 1);
            _waypoints[_waypoints.Length - 1] = GeneratePoint();
        }

        private void GenerateVector4ToGameObject()
        {
            var x = _transformGround.localPosition.x;
            var z = _transformGround.localPosition.z;
            var bounds = _transformGround.GetComponent<MeshFilter>().sharedMesh.bounds;
            _sizeOfPlatform.x = x + bounds.center.x;
            _sizeOfPlatform.y = z + bounds.center.z;
            _sizeOfPlatform.z = bounds.size.x;
            _sizeOfPlatform.w = bounds.size.z;
        }

        public Vector3 GeneratePoint()
        {
            Vector3 result = Vector3.one;
            for (int i = 0; i < 100; i++)
            {
                var x = Random.Range(_sizeOfPlatform.x - (_sizeOfPlatform.z / 2), _sizeOfPlatform.x + (_sizeOfPlatform.z / 2));
                var y = 0.5f;
                var z = Random.Range(_sizeOfPlatform.y - (_sizeOfPlatform.w / 2), _sizeOfPlatform.y + (_sizeOfPlatform.w / 2));
                var checkPoint = new Vector3(x, y, z);
                var _ = new Collider[2];
                int numColliders = Physics.OverlapSphereNonAlloc(checkPoint, 2.0f, _);
                //Debug.Log($"i: {i}, numColliders: {numColliders}");
                if (numColliders == 1)
                {
                    var ct = Instantiate(_prefab, checkPoint, Quaternion.identity);
                    ct.name = name + checkPoint;
                    return checkPoint;
                }
            }

            Instantiate(_prefab, result, Quaternion.identity);

            return result;
        }

        public override void Execute()
        {
            if ((_navMeshAgent.destination - transform.position).sqrMagnitude <= _navMeshAgent.stoppingDistance * _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex]);
            }
        }

        protected override void Interaction()
        {
            print($"Я столкнулся с игроком");
        }

    }
}
