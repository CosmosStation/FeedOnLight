using StarterAssets;
using UnityEngine;
using Interactables;
using Player;

public class Interactor : MonoBehaviour
{
    #region delcarations
    [Space]
    [SerializeField] int _distanceMax = 3;

    [SerializeField] private Player.HandUI _hand;
    [SerializeField] LayerMask layerMaskInteract;
    public enum HandMode { canUse, grab, door, button}

    InteractableObject _interactable;
    RectTransform _handRect;
    Camera _camera;
    private RaycastHit _hit;
    
    private InputHandler _input;

    public float LookSpeedMultiply { get; private set; } = 1;
	#endregion
	
    void Start()
    {
        _input = GetComponent<InputHandler>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; // TODO displace to GameManager

        if (_hand)
        {
            _hand.SetEnableImage(false);
            _handRect = _hand.GetComponent<RectTransform>();
            _handRect.position = new Vector3(Screen.width / 2, Screen.height / 2);
        }
    }

    void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _distanceMax, layerMaskInteract))
        {
            var target = _hit.transform.GetComponent<InteractableObject>();
            if (target)
            {
                if (_hand) _hand.SetEnableImage(true);
                if (!_interactable && _hand) _hand.SetTexture(HandMode.canUse);

                if (_input.interact)
                {
                    Debug.Log("INTERACT");
                    _interactable = target;
                    _interactable.InteractStart(_hit);
                    LookSpeedMultiply = _interactable.LookingSpeed;

                    if (_hand) _hand.SetTexture(_interactable.Hand);
                }
            }
            else if (!_interactable && _hand) _hand.SetEnableImage(false);
        }
        else if (!_interactable && _hand) _hand.SetEnableImage(false);

        if (_interactable == null) return;

        if (_hand) _handRect.position = _camera.WorldToScreenPoint(_interactable.HitPos);
        
        if (!_input.interact) //  || _interactCurerntDistance < _maxInteractDistance
        {
            _interactable.InteractEnd();
            _interactable = null;
            LookSpeedMultiply = 1;
            if (_hand != null)
            {
                _hand.SetEnableImage(false);
                _handRect.position = new Vector3(Screen.width / 2, Screen.height / 2);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        if (_interactable == null)
            Gizmos.color = Color.white;
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_interactable.HitPos, .1f);
        }
        Gizmos.DrawLine(_camera.transform.position,
                        _camera.transform.position + _camera.transform.forward * _distanceMax);
    }
}
