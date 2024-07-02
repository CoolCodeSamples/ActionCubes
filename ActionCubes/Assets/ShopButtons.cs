using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Material material0;
    [SerializeField] private Material material1;

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
                SpendCoins(0);
                SetMaterial(material0);
                break;
            case 1:
                SpendCoins(2);
                SetMaterial(material1);
                break;
        }
    }

    private void SetMaterial(Material newMaterial)
    {

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
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
