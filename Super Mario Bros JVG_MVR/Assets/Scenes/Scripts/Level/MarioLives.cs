using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importar TextMesh Pro

public class MarioLivesManager : MonoBehaviour
{
    public static MarioLivesManager Instance; // Singleton para mantener las vidas entre escenas

    public int maxLives = 3; // Número máximo de vidas
    private int currentLives;

    public TextMeshProUGUI livesText; // Referencia al TextMeshPro en la UI

    private void Awake()
    {
        // Mantener este objeto entre escenas
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

    private void Start()
    {
        if (currentLives == 0)
        {
            currentLives = maxLives; // Inicializar vidas
        }
        UpdateLivesUI(); // Actualizar la UI al iniciar
    }

    public void LoseLife()
    {
        currentLives--;

        if (currentLives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("¡Game Over! No quedan vidas.");
            currentLives = maxLives; // Reiniciar vidas
            SceneManager.LoadScene(0); // Volver a la primera escena
        }

        UpdateLivesUI(); // Actualizar la UI después de perder una vida
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Vidas: " + currentLives; // Actualizar el texto
        }
    }

    public int GetLives()
    {
        return currentLives;
    }

    // Método para asignar el TextMeshPro en caso de que se cargue en una nueva escena
    public void SetLivesText(TextMeshProUGUI text)
    {
        livesText = text;
        UpdateLivesUI();
    }
}
