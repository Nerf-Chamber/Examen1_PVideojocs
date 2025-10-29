using UnityEngine;

public class Chest : MonoBehaviour, IDamageable
{
    public void Hurt(int damage)
    {
        OpenChest();
    }
    private void OpenChest()
    {
        Debug.Log("Chest opened!");
    }
}