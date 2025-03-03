using UnityEngine;

public class Firewall : MonoBehaviour
{
    public float direction;
    public float speed;
    public float bounceForce;
    Rigidbody2D rb2d;
    public GameObject explosion;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        speed *= direction;
        rb2d.linearVelocity = new Vector2(speed, 0);

    }
    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime*-45);
        rb2d.linearVelocity = new Vector2(speed, rb2d.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 sidePoint = collision.GetContact(0).normal;
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.HitFireball();
            Explode(collision.GetContact(0).point);
        }
        else
        {
            if (sidePoint.x != 0)
            {
                Explode(collision.GetContact(0).point);
            }
            else if (sidePoint.y > 0)
            {
                rb2d.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
            else if (sidePoint.y < 0)
            {
                rb2d.AddForce(Vector2.down * bounceForce, ForceMode2D.Impulse);
            }
            else
            {
                Explode(collision.GetContact(0).point);
            }
        }
       
    }
    void Explode (Vector2 point)
    {
        AudioManager.Instance.PlayBump();
        Instantiate(explosion, point, Quaternion.identity);
        Destroy(gameObject);
    }
}
