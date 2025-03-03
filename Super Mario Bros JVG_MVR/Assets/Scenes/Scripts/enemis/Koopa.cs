using UnityEngine;

public class Koopa : Enemy
{
    bool ishidden;

    public float maximotime;

    float stompedTimer;
    public float rolling;

    public bool isRollling;

    protected override void Update()
    {
        base.Update();
        if (ishidden && rb2d.linearVelocity.x == 0f)
        {
            stompedTimer = stompedTimer + Time.deltaTime;
            if (stompedTimer >= maximotime)
            {
                ResetMove();
            }
        }
   
    }

    public override void Stomped( Transform p)
    {
        AudioManager.Instance.PlayStomp();
        isRollling = false;
        if (!ishidden)
        {
            ishidden = true;
            animator.SetBool("hidden",ishidden);
            movimientoWoomba.PausadelmovientoWoomba();
        }
        else
        {
            if (Mathf.Abs(rb2d.linearVelocity.x) > 0f)
            {
                movimientoWoomba.PausadelmovientoWoomba();
            }
            else
            {
                if (p.position.x < transform.position.x)
                {
                    movimientoWoomba.velocidad = rolling;

                }
                else
                {
                    movimientoWoomba.velocidad = -rolling;
                }
                movimientoWoomba.ContinuarMovimiento(new Vector2(movimientoWoomba.velocidad, 0f));
                isRollling = true;
            }
       
 
        }
            gameObject.layer = LayerMask.NameToLayer("OnlyGround");

        Invoke("ResetLayer", 0.1f);
        stompedTimer = 0;
    }
    public override void HitRollingShell()
    {
        if (!isRollling)
        {
            FlipDie();
        }
        else
        {
            movimientoWoomba.ContinuarMovimiento();
        }
    }
    void ResetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

     void ResetMove()
    {
        movimientoWoomba.ContinuarMovimiento();
        ishidden = false;
        animator.SetBool("hidden", ishidden);
        stompedTimer = 0;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRollling)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy")){

                collision.gameObject.GetComponent<Enemy>().HitRollingShell();
            }
        }
    }
}

