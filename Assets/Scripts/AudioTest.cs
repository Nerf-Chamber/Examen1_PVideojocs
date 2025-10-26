using UnityEngine;
using UnityEngine.InputSystem;

// Remember AudioSource component

public class AudioTest : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;

    AudioClip clip = null;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }
    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (AudioManager.Instance.clipList.TryGetValue(AudioClips.Rahhh, out clip))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (AudioManager.Instance.clipList.TryGetValue(AudioClips.Augh, out clip))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}