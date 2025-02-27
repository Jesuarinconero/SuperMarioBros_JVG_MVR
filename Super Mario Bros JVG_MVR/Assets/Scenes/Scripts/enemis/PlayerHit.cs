using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Hit()
    {
        animator.SetTrigger("Hit");
        gameObject.layer = LayerMask.NameToLayer("OnlyGround");
        Destroy(gameObject,1f);
        GetComponent<movimientoWoomba>().PausadelmovientoWoomba();
    }
 
    
}
