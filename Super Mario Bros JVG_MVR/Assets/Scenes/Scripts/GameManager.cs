using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public void GoToLevel(string sceneName)
    {
        Debug.Log("Cambiando a la escena: " + sceneName); // Depuración
        SceneManager.LoadScene(2);
    }
}
