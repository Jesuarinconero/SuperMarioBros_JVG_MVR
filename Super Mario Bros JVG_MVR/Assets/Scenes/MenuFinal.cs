using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Jugar()
    {

        SceneManager.LoadScene(0); // Carga la primera escena del juego



    }
    public void Salir()
    {
        Application.Quit();
    }
}
