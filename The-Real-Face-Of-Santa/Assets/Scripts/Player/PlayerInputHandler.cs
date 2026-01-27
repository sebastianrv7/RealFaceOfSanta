using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.XInput;


public class PlayerInputHandler : MonoBehaviour
{
    public event Action<ICommand> OnCommandGenerated;

    public PlayerInputActions inputActions;

    private PlayerController player;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        player = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {       
        inputActions.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        inputActions.Player.Jump.started += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;

        inputActions.Player.Jump.started -= OnJump;

        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        OnCommandGenerated?.Invoke(new MoveCommand(input.x));
        player.UpdateFacing(input.x);
    }

    private void OnJump(InputAction.CallbackContext context)
    {        
        OnCommandGenerated?.Invoke(new JumpCommand());
    }

    public void DisableInput()
    {
        inputActions.Player.Disable();
    }

    public void EnableInput()
    {
        inputActions.Player.Enable();
    }

}
