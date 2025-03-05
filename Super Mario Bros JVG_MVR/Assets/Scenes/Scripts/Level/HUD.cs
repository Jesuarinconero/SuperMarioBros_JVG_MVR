using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class HUD : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI numCoins;
    public TextMeshProUGUI time;
    private bool isTimeOver = false;
    public Mario mario; // Referencia a Mario

    //int coins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    coins = 0;
    //    numCoins.text = "x" + coins.ToString("D2");
    //}

    // Update is called once per frame
    void Update()
    {
        score.text = ScoreManager.Instance.puntos.ToString(); 
    }
    //public void AddCoins()
    //{
    //    coins++;
    //    numCoins.text = "x" + coins.ToString("D2");
    //}

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
