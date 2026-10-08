using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pattanakan_Methavikul.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rb;
        private InputHandler inputHandler;

        public Transform groundCheck;
        public LayerMask groundLayer;
        // INPUT
        private Vector2 moveInput;
        private bool jumpPressed;
        private bool sprintPressed;

        // VAR

        public float speed = 4f;
        public float jumpForce = 7f;
        private bool isSprinting = false;
        private bool isGrounded = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            inputHandler = GetComponent<InputHandler>();
        }

        // Update is called once per frame
        private void Update()
        {
            moveInput = inputHandler.MoveInput;
            sprintPressed = inputHandler.SprintPressed;
            jumpPressed = inputHandler.JumpPressed;

            HandleMovement();
            CheckGrounded();
        }

        private void HandleMovement()
        {
            isSprinting = sprintPressed;

            Vector3 forward = Vector3.forward;
            Vector3 right = Vector3.right;
            forward.y = right.y = 0f;

            Vector3 moveDir = (forward * moveInput.y + right * moveInput.x).normalized;
            Vector3 targetVel = moveDir * (isSprinting ? speed * 2f : speed);
            targetVel.y = rb.linearVelocity.y;

            // Move Character
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVel, Time.fixedDeltaTime * 10f);

            // Jump
            if (isGrounded && jumpPressed)
            {
                rb.AddForce(Vector3.up * (sprintPressed ? jumpForce * 1.5f : jumpForce), ForceMode.Impulse);
                Debug.Log("J");
            }
        }

        private void CheckGrounded()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        }
    }
}