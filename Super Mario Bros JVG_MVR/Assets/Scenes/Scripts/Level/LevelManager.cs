using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hud;
    int coins;
    public int time;
    public float timer ; 

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = 0;
        timer = time;  // El temporizador empieza en 400
        hud.UpdateTime(timer);
    }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;  // Restar tiempo en lugar de sumarlo
            if (timer < 0) timer = 0; // Asegurar que no baje de 0
            hud.UpdateTime(timer);
        }
    }



    public void AddCoins()
    {
        coins++;
        hud.UpdateCoins(coins);
    }
}
