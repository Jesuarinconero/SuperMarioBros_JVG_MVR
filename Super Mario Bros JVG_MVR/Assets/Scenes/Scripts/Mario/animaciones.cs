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
    public void Shoot()
    {
        animatior.SetTrigger("Shoot");
    }
    public void Hurt(bool activate)
    {
        animatior.SetBool("Hurt", activate);
    }
    public void Agacharse(bool activate)
    {
        animatior.SetBool("agachado", activate);
    }
    public void Climb (bool activate)
    {
        animatior.SetBool("Climb", activate);
    }
    public void Pause()
    {
        animatior.speed = 0;
    }
    public void Continue()
    {
        animatior.speed = 1;
    }
}
