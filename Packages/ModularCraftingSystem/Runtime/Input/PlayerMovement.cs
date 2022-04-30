using UnityEngine;
using UnityEngine.InputSystem;

namespace ModularCraftingSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private PlayerInput playerInput;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 2.0f;
        private float gravityValue = -9.81f;
        public CraftingSystem craftingSystem;

        private void Awake()
        {
            controller = gameObject.GetComponent<CharacterController>();
            playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            playerInput?.Enable();
        }

        private void OnDisable()
        {
            playerInput?.Disable();
        }

        void Update()
        {
            if (Keyboard.current.eKey.isPressed && craftingSystem.gameObject.activeSelf) { craftingSystem.gameObject.SetActive(false); }
            if (Keyboard.current.qKey.isPressed && !craftingSystem.gameObject.activeSelf) { craftingSystem.gameObject.SetActive(true); }

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(playerInput.Keyboard.Movement.ReadValue<Vector2>().x, 0, playerInput.Keyboard.Movement.ReadValue<Vector2>().y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}