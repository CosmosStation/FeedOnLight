using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using StarterAssets;
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
    private AbsorbItem _absorbItem;
    private InspectableItem _inspectableItem;
    private List<Tween> _tweens;


    void FixedUpdate()
    {
        RaycastHit hit;
        
        Transform cameraTransform = camera.transform;
        
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactRange, layerMaskInteract.value))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * hit.distance, Color.green);
            // Debug.Log("Ray hit");
            currentHit = hit;
            hand.transform.localEulerAngles = new Vector3(-35, -39, -121);
            isReadyToInteract = true;
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * interactRange, Color.red);
            // Debug.Log("Ray did not hit");
            hand.transform.localEulerAngles = new Vector3(0, -13, 0);
            isReadyToInteract = false;
        }
    }
    
    public void Interact(StarterAssetsInputs inputInteract)
    {
        if (!isReadyToInteract || !inputInteract.interact) return;
        switch (currentHit.transform.tag)
        {
            case "AbsorbItem":
                GameObject gameObj = currentHit.transform.gameObject;
                _tweens = DOTween.TweensByTarget(gameObj);
                _absorbItem = gameObj.GetComponent<AbsorbItem>();
                _absorbItem.Absorb(_tweens);
                break;
            case "InspectableItem":
                GameObject interactObj = currentHit.transform.gameObject;
                Debug.Log("READING NOTE");
                _inspectableItem = interactObj.GetComponent<InspectableItem>();
                if (_inspectableItem.isInspecting) _inspectableItem.Inspect(false); 
                else _inspectableItem.Inspect(true);
                break;
        }
        inputInteract.interact = false;
    }
    
}
