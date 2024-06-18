using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    private int coins;

    public int GetCoins()
    {
        return coins;
    }

    private void Start()
    {
        LoadCoins();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinsText.text = "COINS: " + coins;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
        UpdateCoinText();
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();
            UpdateCoinText();
            return true;
        }
        return false;
    }
    
}
