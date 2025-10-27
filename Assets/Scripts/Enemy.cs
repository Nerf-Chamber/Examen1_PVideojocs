using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 actualPosition;

    public float _enemyLimitPositionXPositive = 10;
    public float _enemyLimitPositionXNegative = -10;

    public Spawner spawner;

    void Start()
    {
        _rb.linearVelocityX = 2f;
    }

    private void Update()
    {
        if (_rb.position.x >= 10 || _rb.position.x <= -10)
        {
            _rb.linearVelocityX *= -1;
            _rb.transform.position = new Vector2(_rb.transform.position.x, _rb.transform.position.y - 0.02f);
        }
        if (_rb.position.y <= 0)
        {
            spawner.Push(gameObject);
        }
    }
}