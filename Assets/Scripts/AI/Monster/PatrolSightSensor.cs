using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Monster
{
    public class PatrolSightSensor : MonoBehaviour
    {
        public Transform Player;

        [SerializeField] private LayerMask _ignoreMask;

        private Ray _ray;

        public bool CheckIfPlayerInSight()
        {
            if (Player == null)
                return false;

            _ray = new Ray(this.transform.position, Player.position - this.transform.position);

            if (Vector3.Dot(_ray.direction, this.transform.forward) < 0)
                return false;

            if (!Physics.Raycast(_ray, out var hit, 100, ~_ignoreMask))
            {
                return false;
            }

            if (hit.collider.tag == "Player")
            {
                return true;
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_ray.origin, _ray.origin + _ray.direction * 100);
        }
    }
}