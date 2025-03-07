using UnityEngine;
using UnityEngine.SceneManagement;


public class Mario : MonoBehaviour
{
    enum State { Default = 0, Super = 1, Fire = 2 }
    State currentState = State.Default;
    public GameObject pisotear;
    Mover mover;
    Colisiones colisiones;
    animaciones animaciones;
    public Rigidbody2D rb2d;
    bool isDead;
    public GameObject firewallPrefab;
    public Transform Shootpos;
    public bool isHurt;
    public float hurtTime;
    float hurtTimer;
    public bool levelfinish;

    //public HUD hud;
    public bool isAgachado;
    //public GameObject headBox;
    ItemType itemtype;
    private void Awake()
    {
        mover = GetComponent<Mover>();
        colisiones = GetComponent<Colisiones>();
        animaciones = GetComponent<animaciones>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isAgachado = false;
        if (!isDead)
        {
            if (rb2d.linearVelocity.y < 0 && !isDead)
            {
                pisotear.SetActive(true);
            }
            else
            {
                pisotear.SetActive(false);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (colisiones.Suelo())
                {
                    isAgachado = true;
                }
            }


            if (Input.GetKeyDown(KeyCode.Z))
            {
                Shoot();
            }

        }
        if (isHurt)
        {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0)
            {
                endHurt();
            }
        }
        animaciones.Agacharse(isAgachado);

        if (transform.position.y < -10 && !isDead)
        {
            Dead();
        }
        /*if (rb2d.linearVelocity.y > 0 && !isDead)
        {
            headBox.SetActive(true);
        }
        else
        {
            headBox.SetActive(false);
        }*/

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Hit()
    {
        //Debug.Log("Choco con el woomba de tu puta madre :=)");
        if (currentState == State.Default)
        {
            Dead();
        }
        else
        {
            AudioManager.Instance.PlayPowerDown();
            Time.timeScale = 0;
            animaciones.Hit();
            StartHurt();
        }

    }
 void StartHurt()
    {
        isHurt = true;
        animaciones.Hurt(true);
        hurtTimer = hurtTime;
        colisiones.HurtColision(true);
    }
    void endHurt()
    {
        isHurt = false;
        animaciones.Hurt(false);
        colisiones.HurtColision(false);
    }
    public void Dead()
    {
        if (!isDead)
        {
            AudioManager.Instance.PlayDead();
            isDead = true;
            colisiones.Dead();
            mover.Dead();
            animaciones.Dead();

            // En lugar de reiniciar la escena, pierde una vida
            Invoke("LoseLife", 2f);
        }
    }

    void LoseLife()
    {
        MarioLivesManager.Instance.LoseLife();
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0); // Cargar la primera escena (�ndice 0)
    }

    void Changestate(int newStage)
    {
        currentState = (State)newStage;
        animaciones.NewState(newStage);
        Time.timeScale = 1;
    }
    public void CatchItem(ItemType itemtype)
    {
        switch (itemtype)
        {
            case ItemType.MagicMushroom:
                AudioManager.Instance.PlayPowerUp();
                if (currentState == State.Default)
                {
                   
                
                    animaciones.PoweUp();
                    Time.timeScale = 0;
                }
                break;
            case ItemType.FireFlower:
                AudioManager.Instance.PlayPowerUp();
                if (currentState != State.Fire)
                {
                   
                    animaciones.PoweUp();
                    Time.timeScale = 0;
                }
                break;
            case ItemType.Coin:
                AudioManager.Instance.PlayCoin();
                Debug.Log("Monedita");
                LevelManager.Instance.AddCoins();
                break;
            case ItemType.Life:
                break;
            case ItemType.Star:
                break;
            default:
                break;
        }
    }
    void Shoot()
    {
        if (currentState == State.Fire)
        {
            AudioManager.Instance.PlayShoot();
            GameObject nuevaboladefuego = Instantiate(firewallPrefab, Shootpos.position, Quaternion.identity);
            nuevaboladefuego.GetComponent<Firewall>().direction = transform.localScale.x;
            animaciones.Shoot();
        }
    }
    public bool IsBig()
    {
        return currentState != State.Default;
    }
    public bool isSmall()
    {
        return currentState == State.Default;
    }
    public void Goal()
    {
        AudioManager.Instance.PlayFlagPole();
        mover.DownFlagPole();
        levelfinish = true;
    }
  

}