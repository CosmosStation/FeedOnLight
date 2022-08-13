using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("INTERACTION PARAMETERS")]
    public LayerMask layerMaskInteract;

    [SerializeField] private float interactRange = 30f;
    [SerializeField] private GameObject hand;

    private RaycastHit currentHit;
    private bool isReadyToInteract = false;

    [Header("PICKUP PARAMETERS")] 
    [SerializeField] private Transform holdArea;

    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private GameObject heldObj;
    private Rigidbody heldObjRB;
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        
    }
}
