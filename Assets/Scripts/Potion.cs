using UnityEngine;

public class Potion : Item
{
    public override void Use()
    {
        Debug.Log("Healing!");
    }
}