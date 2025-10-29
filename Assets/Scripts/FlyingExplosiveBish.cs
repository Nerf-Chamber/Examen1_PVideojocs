using UnityEngine;

public class FlyingExplosiveBish : Enemy, IFlying, IExplosive
{
    public void Fly()
    {
        Debug.Log("Volando voy");
    }
    public void Explode()
    {
        Debug.Log("Pum, explode!");
    }
}