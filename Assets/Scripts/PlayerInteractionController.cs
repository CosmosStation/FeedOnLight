using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("INTERACTION PARAMETERS")]
    public LayerMask layerMaskInteract;

    [SerializeField] private float interactRange = 30f;
    [SerializeField] private GameObject hand;
    [SerializeField] private Camera camera;

    private RaycastHit currentHit;
    private bool isReadyToInteract = false;
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        RaycastHit hit;
        
        Transform cameraTransform = camera.transform;
        
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactRange, layerMaskInteract.value))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * hit.distance, Color.green);
            // Debug.Log("Ray hit");
            currentHit = hit;
            hand.transform.localEulerAngles = new Vector3(0, -13, 0);
            isReadyToInteract = true;
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * interactRange, Color.red);
            // Debug.Log("Ray did not hit");
            hand.transform.localEulerAngles = new Vector3(45, -13, 0);
            isReadyToInteract = false;
        }
    }
    
    public void Interact(InputAction.CallbackContext context)
    {
        if (!isReadyToInteract || context.phase != InputActionPhase.Performed) return;
        Debug.Log(currentHit);
        switch (currentHit.transform.tag)
        {
            case "AbsorbItem":
                Debug.Log("Absorbing item");
                GameObject gameObj = currentHit.transform.gameObject;
                Debug.Log(gameObj);
                break;
        }
    }
    
}
