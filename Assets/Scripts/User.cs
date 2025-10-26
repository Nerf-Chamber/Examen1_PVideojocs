using UnityEngine;
using UnityEngine.InputSystem;

public class User : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }
    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    public void OnMove(InputAction.CallbackContext context) { Debug.Log("No move in here"); }

    public void OnInteract(InputAction.CallbackContext context) { Debug.Log("No interaction in here"); }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 clickPoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector3.forward, 12f);

            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}