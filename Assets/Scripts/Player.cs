using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject Bullet;

    private Quaternion generalRotation;

    private float timeToWait = 0;
    private float timeBetweenShots = 1f;

    private InputSystem_Actions inputActions;
    public static Vector2 _mousePosition2D;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }
    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Update()
    {
        Vector2 direction = _mousePosition2D - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Around Z
        generalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = generalRotation;
    }

    public void OnChangeMousePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            _mousePosition2D = mousePoint;

            if (Time.time > timeToWait)
            {
                Shoot();
                timeToWait = Time.time + timeBetweenShots;
            }
        }
    }

    // Not used
    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    private void Shoot()
    {
        Instantiate(Bullet, _shootPoint.position, generalRotation);
    }
}