using UnityEngine;

public class Planta : Enemy
{
    public override void HitFireball()
    {
        Destroy(transform.parent.gameObject);
    }
}
