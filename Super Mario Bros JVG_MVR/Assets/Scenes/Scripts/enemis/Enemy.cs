using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator animator;
    protected movimientoWoomba movimientoWoomba;
    protected Rigidbody2D rb2d;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        movimientoWoomba = GetComponent<movimientoWoomba>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {

    }
    public virtual void Stomped(Transform player)
    {

    }
    public virtual void HitFireball()
    {
        FlipDie();
    }

    void FlipDie()
    {
        animator.SetTrigger("Flip");
        rb2d.linearVelocity = Vector2.zero;
        rb2d.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        if (movimientoWoomba != null)
        {
            movimientoWoomba.enabled = true;
        }
        GetComponent<Collider2D>().enabled = false;  
    }


}
