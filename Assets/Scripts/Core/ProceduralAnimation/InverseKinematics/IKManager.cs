using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ProceduralAnimation.InverseKinematics
{
    public class IKManager : MonoBehaviour
    {
        public List<IKJoint> Joints;
        public float SamplingDistance;
        public float LearningRate;
        public float DistanceThreshold;
        
        public Vector3 ForwardKinematics(float[] angles)
        {
            Vector3 prevPoint = Joints[0].transform.position;
            Quaternion rotation = Quaternion.identity;

            for (int i = 0; i < Joints.Count; i++)
            {
                // Rotates around a new axis
                rotation *= Quaternion.AngleAxis(angles[i], Joints[i].Axis);
                Vector3 nextPoint = prevPoint + rotation * Joints[i].StartOffset;

                prevPoint = nextPoint;
            }

            return prevPoint;
        }

        public float DistanceFromTarget(Vector3 target, float[] angles)
        {
            Vector3 point = ForwardKinematics(angles);
            return Vector3.Distance(point, target);
        }

        public float PartialGradient(Vector3 target, float[] angles, int i)
        {
            // Saves the angle,
            // it will be restored later
            float angle = angles[i];
            
            // Gradient : [F(x+SamplingDistance) - F(x)] / h
            float fX = DistanceFromTarget(target, angles);

            angles[i] += SamplingDistance;
            float fXPlusD = DistanceFromTarget(target, angles);

            float gradient = (fXPlusD - fX) / SamplingDistance;
            
            // Restores
            angles[i] = angle;

            return gradient;

        }

        public void InverseKinematics(Vector3 target, float[] angles)
        {
            if (DistanceFromTarget(target, angles) < DistanceThreshold)
                return;
            
            for (int i = 0; i < Joints.Count; i++)
            {
                // Gradient descent
                // Update : Solution -= LearningRate * Gradient
                float gradient = PartialGradient(target, angles, i);
                angles[i] -= LearningRate * gradient;
                
                // Clamp
                angles[i] = Mathf.Clamp(angles[i], Joints[i].MinAngle, Joints[i].MaxAngle);
                
                // Early termination
                if (DistanceFromTarget(target, angles) < DistanceThreshold)
                    return;
            }
        }
    }
}