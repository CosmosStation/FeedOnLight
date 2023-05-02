using UnityEngine;

namespace Core.ProceduralAnimation.InverseKinematics
{
    public class IKJoint : MonoBehaviour
    {
        public Vector3 Axis;
        public Vector3 StartOffset;
        
        public float MinAngle;
        public float MaxAngle;

        void Awake()
        {
            StartOffset = transform.localPosition;
        }
    }
}