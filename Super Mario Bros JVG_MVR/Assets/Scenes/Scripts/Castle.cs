using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public string nextScene = "cambio"; // Nombre de la escena destino
    private bool marioInCastle = false;

    void Update()
    {
        if (marioInCastle && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Intentando cambiar de escena...");

            if (GameManager.Instance == null)
            {
                Debug.LogError("❌ GameManager.Instance es null. ¿Está en la escena?");
                return;
            }

            GameManager.Instance.GoToLevel(nextScene);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
 

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            marioInCastle = false;
        }
    }
}
