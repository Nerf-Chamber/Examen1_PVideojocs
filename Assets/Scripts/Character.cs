using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] protected int HP;

    public void Hurt(int damage)
    {
        Debug.Log("Me doli�, pero me duele m�s un M�xico corrupto");
        HP -= damage;
    }
}