using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] protected int HP;

    public void Hurt(int damage)
    {
        Debug.Log("Me dolió, pero me duele más un México corrupto");
        HP -= damage;
    }
}