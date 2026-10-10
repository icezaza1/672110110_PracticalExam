using UnityEngine;
using UnityEngine.InputSystem;

namespace Pattanakan_Methavikul.Player
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInput playerInput;

        // Public input values
        public Vector2 MoveInput => playerInput?.actions["Move"].ReadValue<Vector2>() ?? Vector2.zero;
        public bool SprintPressed => playerInput?.actions["Sprint"].IsPressed() ?? false;
        public bool JumpPressed => playerInput?.actions["Jump"].WasPressedThisFrame() ?? false;
        public bool InteractPressed => playerInput?.actions["Interact"].WasPressedThisFrame() ?? false;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            if (playerInput != null)
                playerInput.ActivateInput();
        }

        private void OnDisable()
        {
            if (playerInput != null)
                playerInput.DeactivateInput();
        }
    }
}