using System;
using UnityEngine;
using UnityEngine.AI;


namespace JevLogin
{
    public class Ghost : InteractiveObject
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Vector3[] _waypoints;

        private int _currentWaypointIndex;

        private Transform _transformGround;
        private GenerateVectorController _generateVectorController;
        private Vector4 _sizeOfPlatform;
        private Ghost _ghost;

        public Ghost(Ghost ghost)
        {
            _ghost = Instantiate(ghost);
        }

        private void Awake()
        {
            if (_transformGround == null)
            {
                _transformGround = GameObject.FindGameObjectWithTag("Ground").transform;
                Debug.Log($"_transformGround найден {_transformGround}");
            }
            _generateVectorController = new GenerateVectorController();
            _sizeOfPlatform = _generateVectorController.GenerateVector4ToGameObject(_transformGround);
            Debug.Log($"Vector4 _sizeOfPlatform = {_sizeOfPlatform}");
        }

        private void Start()
        {
            var vectorA = _generateVectorController.GetVector3GeneratePoint();

            _ghost.transform.position = vectorA;

            if (_navMeshAgent == null)
            {
                _navMeshAgent = _ghost.GetComponent<NavMeshAgent>();
            }

            var pointSpawn = _generateVectorController.GetVector3GeneratePoint();

            print(pointSpawn);

            if (_waypoints == null || _waypoints.Length == 0)
            {
                _waypoints = new[] { pointSpawn };
            }
            else if (_waypoints.Length == 1)
            {
                _waypoints[0] = pointSpawn;
            }

            //GenerateWaypoints(ref _waypoints);
            GenerateWayPoints();

            _navMeshAgent.SetDestination(_waypoints[0]);

        }

        private void GenerateWayPoints()
        {
            if (_waypoints == null || _waypoints.Length == 0)
            {
                _waypoints = new[] { _generateVectorController.GetVector3GeneratePoint() };
            }

            Array.Resize(ref _waypoints, _waypoints.Length + 1);
            _waypoints[_waypoints.Length - 1] = _generateVectorController.GetVector3GeneratePoint();
            if (_waypoints[_waypoints.Length - 1].Equals(_waypoints[_waypoints.Length - 2]))
            {
                Debug.Log($"точки равны {_waypoints[_waypoints.Length - 1]} and {_waypoints[_waypoints.Length - 2]}");
                _waypoints[_waypoints.Length - 1] = _generateVectorController.GetVector3GeneratePoint();
            }
        }

        public override void Execute()
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
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
