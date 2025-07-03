using UnityEngine;
using System.Collections;

public class NeedsManager : MonoBehaviour
{
    [Header("Системы потребностей")]
    [SerializeField] private FoodSystem foodSystem;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private FunSystem funSystem;

    [Header("Деньги")]
    [SerializeField] private MoneyManager moneyManager;


    private void Start()
    {
        Time.timeScale = 1.0f;
        LoadNeeds();
    }

    public void BuyFood(int cost, int value)
    {
        int current = foodSystem.GetCurrentValue();
        Debug.Log(current);
        if (moneyManager == null || foodSystem == null)
        {
            Debug.LogError("MoneyManager или FoodSystem не присвоены в инспекторе!");
            return;
        }
        if (current >= 100) return;

        if (moneyManager.TrySpendMoney(cost))
        {
            foodSystem.AddValue(value);
            SaveNeeds();
        }
    }
    public void BuyHealth(int cost, int value)
    {
        if (moneyManager == null || healthSystem == null)
        {
            Debug.LogError("MoneyManager или HealthSystem не присвоены!");
            return;
        }

        if (moneyManager.TrySpendMoney(cost))
        {
            healthSystem.AddValue(value);
            SaveNeeds();
        }
    }

    public void BuyFun(int cost, int value)
    {
        if (moneyManager == null || funSystem == null)
        {
            Debug.LogError("MoneyManager или FunSystem не присвоены!");
            return;
        }

        if (moneyManager.TrySpendMoney(cost))
        {
            funSystem.AddValue(value);
            SaveNeeds();
        }
    }

    private void LoadNeeds()
    {
        foodSystem.AddValue(SaveManager.Current.foodCount);
        healthSystem.AddValue(SaveManager.Current.healthCount);
        funSystem.AddValue(SaveManager.Current.funCount);
        moneyManager.AddMoney(SaveManager.Current.money);
    }

    private void SaveNeeds()
    {
        SaveManager.Current.foodCount = foodSystem.GetCurrentValue();
        SaveManager.Current.healthCount = healthSystem.GetCurrentValue();
        SaveManager.Current.funCount = funSystem.GetCurrentValue();
        SaveManager.Current.money = moneyManager.GetCurrentMoney();
    }

}