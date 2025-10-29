using UnityEngine;

public class Pokeball : Item
{
    public override void Use()
    {
        Debug.Log("Y/N tried to capture a Pokemon, although there was no target!");
    }
}