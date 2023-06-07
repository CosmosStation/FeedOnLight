using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class HidePlayer : MonoBehaviour
{
    // [Header("PlayerCapsule")] [SerializeField] private FirstPersonController _controller;


    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "PlayerCapsule") {
            collider.gameObject.GetComponent<FirstPersonController>().hidden = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
         if (collider.gameObject.name == "PlayerCapsule") {
            collider.gameObject.GetComponent<FirstPersonController>().hidden = false;
        }
    }
}