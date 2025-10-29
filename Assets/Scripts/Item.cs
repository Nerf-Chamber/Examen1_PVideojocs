using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }

    public virtual void Use() { }
}