using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyCountText;
    private int currentMoney;

    private void Update()
    {
        currentMoney = Convert.ToInt32(moneyCountText.text);
    }
    public bool TrySpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            return true;
        }
        return false;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        if (moneyCountText != null)
            moneyCountText.text = currentMoney.ToString();
        else
            Debug.LogError("moneyCountText не присвоен!");
        SaveData.money = currentMoney;
    }

    public int GetCurrentMoney() => currentMoney;
}