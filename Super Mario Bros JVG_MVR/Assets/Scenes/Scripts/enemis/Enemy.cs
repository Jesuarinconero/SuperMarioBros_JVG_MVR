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

 
}
