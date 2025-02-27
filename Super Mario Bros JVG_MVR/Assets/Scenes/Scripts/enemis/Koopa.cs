using UnityEngine;

public class Koopa : Enemy
{
    bool ishidden;

    public float maximotime;

    float stompedTimer;
    public float rolling; 

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
            }
       
 
        }
            gameObject.layer = LayerMask.NameToLayer("OnlyGround");

        Invoke("ResetLayer", 0.1f);
        stompedTimer = 0;
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
}

