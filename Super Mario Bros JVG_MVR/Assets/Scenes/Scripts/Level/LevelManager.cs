using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using System.Collections; // Necesario para usar corrutinas

public class LevelManager : MonoBehaviour
{
    public HUD hud;
    public Mario mario;
    int coins;
    public int time;
    public float timer;

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
                StartCoroutine(RestartLevel()); // Inicia el cooldown antes de reiniciar
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

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f); // Cooldown de 3 segundos
        SceneManager.LoadScene(0); // Vuelve a la pantalla de inicio (ajusta el nombre de la escena)
    }
}
