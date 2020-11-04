using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace JevLogin
{
    public class Ghost : InteractiveObject
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform[] _waypoints;

        private int _currentWaypointIndex;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            if (_waypoints == null || _waypoints.Length == 0)
            {
                _waypoints = new[] { transform };
            }
            //Transform tempTransform = 

            //tempTransform.position = new Vector3(transform.position.x + Random.Range(2, 5), transform.position.y, transform.position.z + Random.Range(2, 5));

            print(_waypoints.Length);
            Array.Resize(ref _waypoints, _waypoints.Length + 1);
            print(_waypoints.Length);
            _waypoints[_waypoints.Length - 1] = tempTransform;
            print(_waypoints[1].position);
            _navMeshAgent.SetDestination(_waypoints[0].position);
        }

        public override void Execute()
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            }
        }

        protected override void Interaction()
        {
            throw new System.NotImplementedException();
        }
    }
}
