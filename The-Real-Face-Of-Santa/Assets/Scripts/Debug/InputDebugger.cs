using UnityEngine;
using UnityEngine.InputSystem;

public class InputDebugger : MonoBehaviour
{
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMovePerformed;
        inputActions.Player.Move.canceled += OnMoveCanceled;
        inputActions.Player.Jump.started += OnJumpStarted;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMovePerformed;
        inputActions.Player.Move.canceled -= OnMoveCanceled;
        inputActions.Player.Jump.started -= OnJumpStarted;
        inputActions.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log($"Move PERFORMED: x = {value.x:F2} | y = {value.y:F2}");
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Move CANCELED (tecla soltada)");
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Jump STARTED");
    }
}
