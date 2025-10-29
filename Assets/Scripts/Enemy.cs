using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private GameObject enemy;

    private float speed = 3f;
    private Vector2 _direction = new Vector2(1, 0);

    private bool _hasBounced = false;

    private void Start()
    {
        _mb.Move(_direction, speed);
        // Codi una mica brut, però per veure la funció Invoke
        // Es podria fer dintre d'un update xd
        float random = Random.Range(1f, 3f);
        Invoke("RandomJump", random);
    }
    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        float enemyPositionX = enemy.transform.position.x;
        // Les condicions de límits no estan juntes en un OR per possibles comportaments de col·lisió amb Player
        if (!_hasBounced && enemyPositionX >= 10)
        {
            _direction.x = -1f;
            _mb.Move(_direction, speed);
            _hasBounced = true;
        }
        else if (!_hasBounced && enemyPositionX <= -10)
        {
            _direction.x = 1f;
            _mb.Move(_direction, speed);
            _hasBounced = true;
        }
        else if (enemyPositionX < 10 && enemyPositionX > -10)
        {
            _hasBounced = false;
        }
    }
    private void RandomJump()
    {
        _jb.Jump(150f);
        float random = Random.Range(1f, 3f);
        Invoke("RandomJump", random);
    }
}