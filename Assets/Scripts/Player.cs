using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions _inputActions;

    void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }
    public void OnEnable() => _inputActions.Enable();
    public void OnDisable() => _inputActions.Disable();

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Saltiño");
        _jb.Jump(50f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        direction.y = 0;
        _mb.Move(direction, 3f);
    }

    // Unused in this exercise
    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}