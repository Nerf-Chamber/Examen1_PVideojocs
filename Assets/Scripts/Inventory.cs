using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private Item _currentItem;

    private float timeToWaitCHA = 0;
    private float timeToWaitUSE = 0;
    private float timeBetweenAction = 0.3f;

    private int numItem = 0;
    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
        _currentItem = _items[numItem];
    }

    public void OnEnable() => _inputActions.Enable();
    public void OnDisable() => _inputActions.Disable();

    public void OnChangeItem(InputAction.CallbackContext context)
    {
        if (Time.time >= timeToWaitCHA)
        {
            numItem = (numItem + 1) % _items.Count;

            _currentItem = _items[numItem];
            Debug.Log($"Switched to item: {_currentItem.name}");
            timeToWaitCHA = Time.time + timeBetweenAction;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (Time.time >= timeToWaitUSE)
        {
            _currentItem.Use();
            timeToWaitUSE = Time.time + timeBetweenAction;
        }
    }
}