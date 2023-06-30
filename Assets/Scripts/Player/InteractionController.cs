using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Interactables;

namespace Player
{
    public class InteractionController : MonoBehaviour
    {
        [Header("OUTSIDE INFLUENCE")] [SerializeField]
        private GrabMethods MonsterGrabManager;

        private bool _isGrabbed = false;

        [Header("INTERACTION PARAMETERS")] public LayerMask layerMaskInteract;
        [SerializeField] int _distanceMax = 3;
        [SerializeField] HandUI _hand;
        public float LookSpeedMultiply { get; private set; } = 1;
        InteractableObject _interactable;
        RectTransform _handRect;

        [SerializeField] private float interactRange = 30f;

        //[SerializeField] private float ThrowStrength = 50f;
        [SerializeField] private float distance = 3f;
        [SerializeField] private float maxDistanceGrab = 4f;
        [SerializeField] private GameObject hand;
        [SerializeField] private Camera playerCamera;

        private RaycastHit currentHit;
        private bool isReadyToInteract = false;

        private AbsorbItem _absorbItem;

        // private ChangeColorItem _changeColorItem;
        private ItemPickUp _pickUpItem;
        private InspectableItem _inspectableItem;
        private List<Tween> _tweens;
        private GameObject objectHeld;
        private bool isObjectHeld;
        private bool tryPickupObject;

        void Start()
        {
            isObjectHeld = false;
            tryPickupObject = false;
            objectHeld = null;

            GameEvents.current.onPlayerGrabbed += onGrabbed;
        }

        void onGrabbed()
        {
            Debug.Log("Player Grabbed");
            _isGrabbed = true;
        }

        void FixedUpdate()
        {
            if (isObjectHeld || true)
            {
                // HoldObject();
            }
            else
            {
                RaycastHit hit;

                Transform playerCameraTransform = playerCamera.transform;

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit,
                        interactRange,
                        layerMaskInteract.value))
                {
                    Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hit.distance,
                        Color.green);
                    // Debug.Log("Ray hit");
                    currentHit = hit;
                    hand.transform.localEulerAngles = new Vector3(-35, -39, -121);
                    isReadyToInteract = true;
                }
                else
                {
                    Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * interactRange,
                        Color.red);
                    // Debug.Log("Ray did not hit");
                    hand.transform.localEulerAngles = new Vector3(0, -13, 0);
                    isReadyToInteract = false;
                }
            }
        }

        public void Shoot(InputClass inputShoot)
        {

        }

        public void Interact(bool inputInteract)
        {
            // Если ты схвачен, вместо того чтобы интерактировать, ты пытаешься выбраться
            if (_isGrabbed)
            {
                MonsterGrabManager.DoResist();
                if (MonsterGrabManager.checkIsGrabbed() == false)
                {
                    _isGrabbed = false;
                }

                return;
            }

            return;

            if ((!objectHeld && !isReadyToInteract)) return;
            if (!inputInteract && isObjectHeld)
            {
                isObjectHeld = false;
                objectHeld.GetComponent<Rigidbody>().useGravity = true;
                objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
                objectHeld = null;
                return;
            }
            else if (isReadyToInteract && inputInteract)
            {
                switch (currentHit.transform.tag)
                {
                    case "PickUpItem":
                        objectHeld = currentHit.transform.gameObject;
                        _pickUpItem = objectHeld.GetComponent<ItemPickUp>();
                        _pickUpItem.PickUp();
                        break;
                    case "AbsorbItem":
                        objectHeld = currentHit.transform.gameObject;
                        _tweens = DOTween.TweensByTarget(objectHeld);
                        _absorbItem = objectHeld.GetComponent<AbsorbItem>();
                        _absorbItem.Absorb(_tweens);
                        break;
                    case "InspectableItem":
                        isObjectHeld = true;
                        objectHeld = currentHit.transform.gameObject;
                        Debug.Log("READING NOTE");
                        _inspectableItem = objectHeld.GetComponent<InspectableItem>();
                        if (_inspectableItem.isInspecting) _inspectableItem.Inspect(false);
                        else _inspectableItem.Inspect(true);
                        break;
                    case "Door":
                        objectHeld = currentHit.transform.gameObject;
                        isObjectHeld = true;
                        DoorController door = objectHeld.GetComponent<DoorController>();
                        door.UnlockDoor();
                        break;
                    case "Interact":
                        objectHeld = currentHit.transform.gameObject;
                        isObjectHeld = true;
                        Debug.Log("Interact");
                        objectHeld.GetComponent<Rigidbody>().useGravity = true;
                        objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
                        break;
                    case "InteractItem":
                        objectHeld = currentHit.transform.gameObject;
                        isObjectHeld = true;
                        Debug.Log("InteractItem");
                        objectHeld.GetComponent<Rigidbody>().useGravity = true;
                        objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
                        break;
                }
            }
        }

        private void HoldObject()
        {
            Ray playerAim = playerCamera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            Vector3 nextPos = playerCamera.transform.position + playerAim.direction * distance;
            Vector3 currPos = objectHeld.transform.position;

            objectHeld.GetComponent<Rigidbody>().velocity = (nextPos - currPos) * 10;

            if (Vector3.Distance(objectHeld.transform.position, playerCamera.transform.position) > maxDistanceGrab)
            {
                DropObject();
            }
        }

        private void DropObject()
        {
            isObjectHeld = false;
            tryPickupObject = false;
            objectHeld.GetComponent<Rigidbody>().useGravity = true;
            objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
            objectHeld = null;
        }
    }
}
