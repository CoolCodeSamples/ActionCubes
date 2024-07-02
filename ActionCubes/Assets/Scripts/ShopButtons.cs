using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private int coins;

    private void Start()
    {
        LoadCoins();
    }

    public void BuySkin(int skinIndex)
    {
        print(skinIndex);
        switch (skinIndex)
        {
            case 0:
                SetMaterial(skinIndex);
                break;
            case 1:
                if (SpendCoins(10))
                {
                    SetMaterial(skinIndex);
                }
                break;
            case 2:
                if (SpendCoins(9162))
                {
                    SetMaterial(skinIndex);
                }
                break;
        }
    }

    private void SetMaterial(int skinIndex)
    {
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.Save();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
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

    private void UpdateCoinText()
    {
        coinsText.text = "COINS: " + coins;
    }
}
