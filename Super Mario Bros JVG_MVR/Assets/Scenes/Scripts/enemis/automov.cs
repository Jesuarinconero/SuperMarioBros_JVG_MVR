using UnityEngine;

public class movimientoWoomba : MonoBehaviour
{
    public float velocidad = -1f;
    bool movimientoenpausa; 
    Rigidbody2D rb2d;
    SpriteRenderer spriterender;
    Vector2 lastvelocidad;
    Vector2 currentDirection;
    float defaultSpeed;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriterender = GetComponent < SpriteRenderer > ();
    }
    private void Start()
    {

        rb2d.linearVelocity = new Vector2(velocidad, rb2d.linearVelocity.y);
        defaultSpeed = Mathf.Abs(velocidad);
    }
    private void FixedUpdate()
    {
        if (!movimientoenpausa)
        {
            if (rb2d.linearVelocity.x > -0.1f && rb2d.linearVelocity.x < 0.1f)
            {
                velocidad = -velocidad;
            }
            rb2d.linearVelocity = new Vector2(velocidad, rb2d.linearVelocity.y);
            if (rb2d.linearVelocity.x > 0)
            {
                spriterender.flipX = true;

            }
            else
            {
                spriterender.flipX = false;
            }
            

            
        }


    }

    public void ContinuarMovimiento()
    {
        if (movimientoenpausa)
        {
            velocidad = defaultSpeed* currentDirection.x ;
            movimientoenpausa = false;
            rb2d.linearVelocity = new Vector2(velocidad, rb2d.linearVelocity.y);
        }
    }
    public void PausadelmovientoWoomba()
    {
        if (!movimientoenpausa)
        {
            currentDirection = rb2d.linearVelocity.normalized;
            lastvelocidad = rb2d.linearVelocity;
            movimientoenpausa = true;
            rb2d.linearVelocity = new Vector2(0, 0);
        }
    }
    public void ContinuarMovimiento(Vector2 nuevaVelocidad)
    {
        if (movimientoenpausa)
        {
            rb2d.linearVelocity = nuevaVelocidad;
            movimientoenpausa = false;
        }
    }

}
