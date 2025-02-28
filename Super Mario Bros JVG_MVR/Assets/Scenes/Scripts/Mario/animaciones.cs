using UnityEngine;

public class animaciones : MonoBehaviour
{
    Animator animatior;
    //Colisiones colisiones;
    //Mover mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animatior = GetComponent<Animator>();
        //colisiones = GetComponent<Colisiones>();
        //mover = GetComponent<Mover>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     
       
        
    }
    public void Grounded(bool esSuelo)
    {

        animatior.SetBool("Grounded", esSuelo);
    }
    public void Velocidad(float velocidadx)
    {
        animatior.SetFloat("velocidadx", velocidadx);
    }
    public void Salto(bool isJumping)
    {
        animatior.SetBool("salto", isJumping);
    }
    public void Deslizarse(bool isSkidding)
    {

        animatior.SetBool("deslizarse", isSkidding);
    }
    public void Dead()
    {
        animatior.SetTrigger("death");
    }
    public void NewState(int state)
    {
        animatior.SetInteger("States", state);
    }
    public void PoweUp()
    {
        animatior.SetTrigger("PowerUp");
    }
    public void Hit()
    {
        animatior.SetTrigger("Hit");
    }
}
