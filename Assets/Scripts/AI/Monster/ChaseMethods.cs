using UnityEngine;

namespace AI.Monster
{
    public class ChaseMethods : MonoBehaviour
    {
        public Transform Player;
        public Transform Monster;

        [SerializeField] private LayerMask _ignoreMask;

        private Ray _ray;

        public bool CheckIfPlayerInSight()
        {
            if (Player == null)
                return false;

            _ray = new Ray(Monster.position, Player.position - Monster.transform.position);

            if (Vector3.Dot(_ray.direction, Monster.transform.forward) < 0)
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
