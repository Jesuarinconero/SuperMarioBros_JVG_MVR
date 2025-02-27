using UnityEngine;

public class Goomba : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void Stomped(Transform p)
    {
        animator.SetTrigger("Hit");
        gameObject.layer = LayerMask.NameToLayer("OnlyGround");
        Destroy(gameObject, 1f);
        movimientoWoomba.PausadelmovientoWoomba();
    }
}
