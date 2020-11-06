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

        private Ghost _ghost;

        public Ghost(Ghost ghost, Vector3 pointSpawn)
        {
            _ghost = Instantiate(ghost);
            if (_waypoints == null || _waypoints.Length == 0)
            {
                _waypoints = new[] { pointSpawn };
            }
            else if (_waypoints.Length == 1)
            {
                _waypoints[0] = pointSpawn;
            }
        }

        private void Start()
        {
            if (_navMeshAgent == null)
            {
                _navMeshAgent = GetComponent<NavMeshAgent>();
            }


            //GenerateWaypoints(ref _waypoints);

            _navMeshAgent.SetDestination(_waypoints[0]);

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
