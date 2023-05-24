using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump = false;
		public bool sprint = false;
		public bool interact = false;
		public bool crouch = false;
		public bool light = false;
		public bool openInventory = false;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		public bool action = false;
		public bool altAction = false;

		[Header("Interaction")] public PlayerInteractionController Interaction;

		[Header("Light")] public LightController Light;

		[Header("Inventory")] public InventoryController Inventory;
		
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnCrouch(InputValue value)
		{
			CrouchInput(value.isPressed);
		}

		public void OnLight(InputValue value)
		{
			LightInput(value.isPressed);
		}
		
		public void OnInteract(InputValue value)
		{
			InteractInput(value.isPressed);
		}
		
		public void OnAction(InputValue value)
		{
			ActionInput(value.isPressed);
		}
		
		public void OnAltAction(InputValue value)
		{
			AltActionInput(value.isPressed);
		}

		public void OnOpenInventory(InputValue value)
        {
			OpenInventoryInput(value.isPressed);
        }
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}
		
		public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
			Interaction.Interact(interact);
		}
		
		public void ActionInput(bool newActionState)
		{
			interact = newActionState;
		}
		
		public void AltActionInput(bool newAltActionState)
		{
			interact = newAltActionState;
		}
		

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void CrouchInput(bool newCrouchState)
		{
			crouch = newCrouchState;
		}

		public void LightInput(bool newLightState)
		{
			light = newLightState;
			Light.Turn();
		}

		public void OpenInventoryInput(bool newOpenInventoryState)
        {
			openInventory = newOpenInventoryState;
			Inventory.OpenInventory();
        }


		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}