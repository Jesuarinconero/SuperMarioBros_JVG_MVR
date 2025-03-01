using UnityEngine;

public class Mario : MonoBehaviour
{
    enum State { Default = 0, Super = 1, Fire = 2 }
    State currentState = State.Default;
    public GameObject pisotear;
    Mover mover;
    Colisiones colisiones;
    animaciones animaciones;
    Rigidbody2D rb2d;
    bool isDead;


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
        if (rb2d.linearVelocity.y < 0 && !isDead)
        {
            pisotear.SetActive(true);
        }
        else
        {
            pisotear.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            animaciones.PoweUp();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Time.timeScale = 0;
            animaciones.Hit();
        }
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
            animaciones.Hit();
        }

    }
    public void Dead()
    {
        if (!isDead)
        {
            isDead = true;
            colisiones.Dead();
            mover.Dead();
            animaciones.Dead();
        }

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
                if (currentState == State.Default)
                {
                    Time.timeScale = 0;
                    animaciones.PoweUp();
                }
                break;
            case ItemType.FireFlower:
                if(currentState != State.Fire)
                {
                    Time.timeScale = 0;
                    animaciones.PoweUp();
                }
                break;
            case ItemType.Coin:
                Debug.Log("Monedita");
                break;
            case ItemType.Life:
                break;
            case ItemType.Star:
                break;
            default:
                break;
        }
    }

}