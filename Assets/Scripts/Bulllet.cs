using UnityEngine;

public class Bulllet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        _rb.linearVelocity = transform.position.normalized * 2f;
    }
}