using UnityEngine;

public class Mover : MonoBehaviour
{
    //Variable de velocidad del personaje
    public float velocidad ;
    public Rigidbody2D rb2;
    enum Direccion { Left = -1, None = 0 , Right = 1};
    Direccion currentDirection = Direccion.None;
    Colisiones colisones;
    public float aceleracion;
    public float maximavelocidad;
    public float friccion;
    public float currentVelocidad = 0f;



    public float fuerzadesalto;
    public float maximosalto = 1f;
    public bool isjumping;
    public bool isSkidding;
    float saltotimer = 0;
    float defaultgravedad;
    public bool inputMoveEnable = true;

    animaciones animaciones;






    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        colisones = GetComponent<Colisiones>();
        animaciones = GetComponent<animaciones>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultgravedad = rb2.gravityScale;


    }

    // Update is called once per frame
    void Update()
    {
        bool suelo = colisones.Suelo();
        animaciones.Grounded(suelo);

        if (isjumping)
        {
            if(rb2.linearVelocity.y <= 0f)
            {
                rb2.gravityScale = defaultgravedad;
                if (suelo)
                {
                    isjumping = false;
                    saltotimer = 0;
                    animaciones.Salto(false);
                }
            }
             if (rb2.linearVelocity.y > 0f)
            {
                if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                {
                    saltotimer += Time.deltaTime;
                }
                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    if (saltotimer < maximosalto)
                    {
                        rb2.gravityScale = defaultgravedad * 3f;
                    }
                }
                {

                }
            }
        }

        currentDirection = Direccion.None;
        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, velocidad*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -velocidad * Time.deltaTime, 0);
        }*/
        if (inputMoveEnable)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (suelo)
                {
                    Saltar();
                }

            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // transform.Translate(-velocidad * Time.deltaTime, 0, 0);
                currentDirection = Direccion.Left;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // transform.Translate(velocidad * Time.deltaTime, 0, 0);
                currentDirection = Direccion.Right;
            }

        }
    
   

    }
    private void FixedUpdate()
    {
        /*
        Vector2 fuerzaacelaracion = new Vector2((int) currentDirection *aceleracion , 0f);
        rb2.AddForce(fuerzaacelaracion);
        //Funcion matematica de unity para dejar fija una max y una minima aceleracion
       // float velocidadx = Mathf.Clamp(rb2.velocity.x , -maximaacelaracion , maximaacelaracion);
  
        Vector2 movimiento = new Vector2(velocidadx, rb2.linearVelocity.y);
        rb2.linearVelocity = movimiento;*/
        isSkidding = false;

        currentVelocidad = rb2.linearVelocity.x;
        if (currentDirection > 0)
        {

            if (currentVelocidad < 0) {
                currentVelocidad += ((aceleracion + friccion) * Time.deltaTime);
                isSkidding = true;
            }else if (currentVelocidad < maximavelocidad)
            {
                currentVelocidad += aceleracion * Time.deltaTime;
                transform.localScale = new Vector2(1,1);
            }
        }
        else if (currentDirection < 0)
        {
            if(currentVelocidad > 0)
            {
                currentVelocidad -= ((aceleracion + friccion) * Time.deltaTime);
                isSkidding = true;
            }
            else if (currentVelocidad > -maximavelocidad)
            {
                currentVelocidad -= aceleracion * Time.deltaTime;
                transform.localScale = new Vector2(-1,1);
            }
        }
        else
        {
            if (currentVelocidad > 1f)
            {
                currentVelocidad -= friccion * Time.deltaTime;
            }else if (currentVelocidad < -1f)
            {
                currentVelocidad += friccion * Time.deltaTime;
            }else
            {
                currentVelocidad = 0;
            }
        }
        Vector2 velocidad = new Vector2(currentVelocidad, rb2.linearVelocity.y);
        rb2.linearVelocity = velocidad;
        animaciones.Velocidad(Mathf.Abs(currentVelocidad));

        animaciones.Deslizarse(isSkidding);
        
    }
    void Saltar()
    {
        if ( !isjumping)
        {
            isjumping = true;
            Vector2 fuezadesalto = new Vector2(0, fuerzadesalto);
            rb2.AddForce(fuezadesalto, ForceMode2D.Impulse);
            animaciones.Salto(true);

        }

  
    }
    void MovimientoDerecha()
    {
        //Vector2 fuezadesalto = new Vector2(10f, 0);
        //rb2.AddForce(fuezadesalto, ForceMode2D.Impulse);
        Vector2 velocidad = new Vector2(1f, 0f);
        rb2.linearVelocity = velocidad;


    }
    public void Dead()
    {
        inputMoveEnable = false;
        rb2.linearVelocity = Vector2.zero;
        rb2.gravityScale = 1;
        rb2.AddForce(Vector2.up*5 , ForceMode2D.Impulse);
     }
    public void BounceUp()
    {
        rb2.linearVelocity = Vector2.zero;
        rb2.AddForce(Vector2.up*10f, ForceMode2D.Impulse);
     }
}
