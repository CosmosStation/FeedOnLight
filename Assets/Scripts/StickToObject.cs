using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 localOffset;
    public Vector3 localRotation;

    private void Update()
    {
        if (targetObject == null)
        {
            return;
        }

        transform.position = targetObject.transform.TransformPoint(localOffset);
        transform.rotation = targetObject.transform.rotation * Quaternion.Euler(localRotation);
    }
}
