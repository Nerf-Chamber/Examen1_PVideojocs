using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private int damage;

    private Vector3 mousePosition;
    private bool _canAttack = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<IDamageable>(out IDamageable iDmg) && _canAttack)
        {
            // Crida a Hurt() de l'objecte col·lisionat
            iDmg.Hurt(damage);
            _canAttack = false;
            Invoke("CanAttackAgain", 2f);
        }
    }
    public void CanAttackAgain()
    {
        _canAttack = true;
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, 0.1f);
    }
}