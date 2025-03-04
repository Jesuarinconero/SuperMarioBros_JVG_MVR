using UnityEngine;

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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegurar que Mario tiene el tag "Player"
        {
            marioInCastle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            marioInCastle = false;
        }
    }
}
