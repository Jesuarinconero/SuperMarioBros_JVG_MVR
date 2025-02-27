using UnityEngine;

public class movimientoWoomba : MonoBehaviour
{
    public float velocidad = -1f;
    bool movimientoenpausa; 
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {

        rb2d.linearVelocity = new Vector2(velocidad, rb2d.linearVelocity.y);
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
        }


    }
    public void PausadelmovientoWoomba()
    {
        if (!movimientoenpausa)
        {
            movimientoenpausa = true;
            rb2d.linearVelocity = new Vector2(0, 0);
        }
    }
}
