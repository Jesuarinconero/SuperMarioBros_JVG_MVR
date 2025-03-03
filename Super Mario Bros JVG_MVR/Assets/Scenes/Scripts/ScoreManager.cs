using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int puntos;

    public static ScoreManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        puntos = 0;

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
    }
}
