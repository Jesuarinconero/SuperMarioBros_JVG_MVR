using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hud;
    public Mario mario;  // Referencia a Mario
    int coins;
    public int time;
    public float timer;

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        coins = 0;
        timer = time;
        hud.UpdateTime(timer);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                hud.UpdateTime(timer);
                mario.Dead();  // Mario muere cuando el tiempo llega a 0
            }
            else
            {
                hud.UpdateTime(timer);
            }
        }
    }

    public void AddCoins()
    {
        coins++;
        hud.UpdateCoins(coins);
    }
}
