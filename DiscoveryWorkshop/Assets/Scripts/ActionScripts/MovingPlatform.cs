using System.Collections.Generic;
using UnityEngine;

namespace ActionScripts
{
    public class MovingPlatform: Action
    {
     
        [SerializeField] private List<Transform> waypoints;
        [SerializeField] private float moveSpeed = 5f;
        private int _currentWaypoint;

        // Start is called before the first frame update
        private void Start()
        {
            if (waypoints.Count <= 0) return;
            _currentWaypoint = 0;
        }

        public override void DoAction()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
                (moveSpeed * Time.deltaTime));

            if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0)
            {
                _currentWaypoint++;
            }

            if (_currentWaypoint != waypoints.Count)
            {
                return;
            }
            waypoints.Reverse();
            _currentWaypoint = 0;
        }
    }
}