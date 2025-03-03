using UnityEngine;

public class Planta : Enemy
{
    public override void HitFireball()
    {
        Dead();
        Destroy(transform.parent.gameObject);
    }
    public override void HitRollingShell()
    {
        Dead();
        Destroy(transform.parent.gameObject);
    }
}
