using UnityEngine;
using UnityEngine.SceneManagement;

public class menuinicial : MonoBehaviour
{
    private MusicaInicio musicaInicio;

    private void Awake()
    {
        musicaInicio = FindObjectOfType<MusicaInicio>();

        if (musicaInicio == null)
        {
            Debug.LogWarning("No se encontró el script MusicaInicio en la escena.");
        }
    }

    void Start()
    {
        if (musicaInicio != null)
        {
            musicaInicio.Musicainicio(); // ← Reproduce la música al iniciar
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
