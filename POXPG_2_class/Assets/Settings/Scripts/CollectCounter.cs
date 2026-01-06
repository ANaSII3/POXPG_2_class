using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCounter : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    public void SetCoins(int value)
    {
        coins = value;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Apples: " + coins;
    }
}