using UnityEngine;

public class Mover : MonoBehaviour
{
    //Variable de velocidad del personaje
    public float velocidad ;
     Rigidbody2D rb2;
    enum Direccion { Left = -1, None = 0 , Right = 1};
    Direccion currentDirection = Direccion.None;
    Colisiones colisones;



    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        colisones = GetComponent<Colisiones>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
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
    private void FixedUpdate()
    {
        Vector2 movimiento = new Vector2((int) currentDirection *velocidad , rb2.linearVelocity.y);
        rb2.linearVelocity = movimiento;
    }
    void Saltar()
    {
        if (colisones.Suelo())
        {
            Vector2 fuezadesalto = new Vector2(0, 10f);
            rb2.AddForce(fuezadesalto, ForceMode2D.Impulse);

        }

  
    }
    void MovimientoDerecha()
    {
        //Vector2 fuezadesalto = new Vector2(10f, 0);
        //rb2.AddForce(fuezadesalto, ForceMode2D.Impulse);
        Vector2 velocidad = new Vector2(1f, 0f);
        rb2.linearVelocity = velocidad;


    }
}
