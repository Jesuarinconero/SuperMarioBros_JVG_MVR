using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI numCoins;
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
}
