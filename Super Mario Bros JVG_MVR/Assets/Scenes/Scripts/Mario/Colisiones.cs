using UnityEngine;

public class Colisiones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool colisionesconelsuelo;
    public Transform checkearsuelo;
    public float suelocheckeadoRadio;
    public LayerMask sueloLayer;
    Mario mario;
    Mover mover;


    BoxCollider2D cold2d;
    private void Awake()
    {
        cold2d = GetComponent<BoxCollider2D>();
        mario = GetComponent<Mario>();
        mover = GetComponent<Mover>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Suelo()
    {
        //Nos comunica si colisiona con el suelo o no
        // colisionesconelsuelo = Physics2D.OverlapCircle(checkearsuelo.position, suelocheckeadoRadio, sueloLayer);
        Vector2 piesizquierdo = new Vector2(cold2d.bounds.center.x - cold2d.bounds.extents.x , cold2d.bounds.center.y);
        Vector2 piesDerecho = new Vector2(cold2d.bounds.center.x + cold2d.bounds.extents.x , cold2d.bounds.center.y);

        
        Debug.DrawRay(piesizquierdo,Vector2.down * cold2d.bounds.extents.y*1.5f,Color.magenta);
        Debug.DrawRay(piesDerecho, Vector2.down * cold2d.bounds.extents.y * 1.5f, Color.magenta);
        if(Physics2D.Raycast(piesizquierdo,Vector2.down, cold2d.bounds.extents.y * 1.5f , sueloLayer))
        {
            colisionesconelsuelo = true;
        }
        else if(Physics2D.Raycast(piesDerecho, Vector2.down, cold2d.bounds.extents.y * 1.5f, sueloLayer))
        {
            colisionesconelsuelo = true;
        }
        else
        {
            colisionesconelsuelo = false;
        }
            return colisionesconelsuelo;
    }
    private void FixedUpdate()

    {
        colisionesconelsuelo = Physics2D.OverlapCircle(checkearsuelo.position, suelocheckeadoRadio, sueloLayer);
    }
    public void Dead()
    {
        gameObject.layer = LayerMask.NameToLayer("Playerdeath");
        foreach(Transform t in transform)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Playerdeath");
        }
    }
    public void HurtColision(bool activate)
    {
        if (activate)
        {
            gameObject.layer = LayerMask.NameToLayer("OnlyGround");
            transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("OnlyGround");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            mario.Hit();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*  PlayerHit playerHit = collision.GetComponent<PlayerHit>();
          if(playerHit != null)
          {
              playerHit.Hit();
              mover.BounceUp();
          }
      }*/

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (collision.CompareTag("Planta"))
            {
                mario.Hit();
            }
            else
            {
                enemy.Stomped(transform);
                mover.BounceUp();
            }
       
        }
    }
}
