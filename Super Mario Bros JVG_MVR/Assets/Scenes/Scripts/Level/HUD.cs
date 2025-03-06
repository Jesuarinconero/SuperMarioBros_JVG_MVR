using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI numCoins;
    public TextMeshProUGUI time;
    private bool isTimeOver = false;
    public Mario mario; // Referencia a Mario

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Mantener el HUD entre escenas
    }

    private void Update()
    {
        CheckScene();
        score.text = ScoreManager.Instance.puntos.ToString();
    }

    private void CheckScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Si estamos en el menú (índice 0) o en la escena final (índice 3), destruir el HUD
        if (currentSceneIndex == 0 || currentSceneIndex == 3)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCoins(int totalCoins)
    {
        numCoins.text = "x" + totalCoins.ToString("D2");
    }

    public void UpdateTime(float timeLeft)
    {
        int timeLeftInt = Mathf.RoundToInt(timeLeft);
        time.text = timeLeftInt.ToString("D3"); // Asegura que el tiempo tenga 3 dígitos
    }
}
