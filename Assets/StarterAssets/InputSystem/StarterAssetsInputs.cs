using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            if (!inputDisabled) // Check if input is disabled
            {
                MoveInput(value.Get<Vector2>());
            }
        }

        public void OnLook(InputValue value)
        {
            if (!inputDisabled && cursorInputForLook) // Check if input is disabled and cursor input is enabled
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            if (!inputDisabled) // Check if input is disabled
            {
                JumpInput(value.isPressed);
            }
        }

        public void OnSprint(InputValue value)
        {
            if (!inputDisabled) // Check if input is disabled
            {
                SprintInput(value.isPressed);
            }
        }
#endif

        private bool inputDisabled = false; // Flag to track if input is disabled

        public void DisableInput()
        {
            inputDisabled = true; // Set input disabled flag
            SetCursorState(false); // Unlock the cursor
        }

        public void EnableInput()
        {
            inputDisabled = false; // Set input enabled flag
            SetCursorState(cursorLocked); // Lock or unlock the cursor based on cursorLocked setting
        }

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

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !newState; // Show cursor if locked, hide cursor if unlocked
        }
    }
}
