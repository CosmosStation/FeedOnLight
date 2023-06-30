using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace Player
{
	public class InputHandler : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool crouch;
		public bool lightState;
		public bool openInventory;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		public bool action;
		public bool altAction;

		[Header("Interaction")] public InteractionController interaction;

		[Header("Light")] public LightController lightController;

		[Header("Inventory")] public InventoryController inventory;

		[Header("Player Grabbed by Monster")] public GrabMethods grabMethods;

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


		private void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		private void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		private void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}
		
		private void InteractInput(bool newInteractState)
		{
			Debug.Log(newInteractState);
			interact = newInteractState;
			interaction.Interact(interact);
		}
		
		private void ActionInput(bool newActionState)
		{
			interact = newActionState;
		}
		
		private void AltActionInput(bool newAltActionState)
		{
			interact = newAltActionState;
		}
		

		private void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void CrouchInput(bool newCrouchState)
		{
			crouch = newCrouchState;
		}

		private void LightInput(bool newLightState)
		{
			lightState = newLightState;
			lightController.Turn();
		}

		private void OpenInventoryInput(bool newOpenInventoryState)
        {
			openInventory = newOpenInventoryState;
			inventory.OpenInventory();
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