using UnityEngine;

public class Mario : MonoBehaviour
{
    public GameObject pisotear;
    Mover mover;
    Colisiones colisiones;
    animaciones animaciones;
    Rigidbody2D rb2d;
    private void Awake()
    {
        mover = GetComponent<Mover>();
        colisiones = GetComponent<Colisiones>();
        animaciones = GetComponent<animaciones>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(rb2d.linearVelocity.y <0)
        {
            pisotear.SetActive(true);
        }
        else
        {
            pisotear.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Hit()
    {
        //Debug.Log("Choco con el woomba de tu puta madre :=)");

        Dead();
    }
    public void Dead()
    {
        colisiones.Dead();
        mover.Dead();
        animaciones.Dead();
    }
}
