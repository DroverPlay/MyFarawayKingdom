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

    [Header("Настройки убывания")]
    [SerializeField] private int healthDrainRate;
    [SerializeField] private int funDrainRate;

    private float _drainSpeed;

    private void Start()
    {
        Time.timeScale = 1.0f;
        LoadNeeds();
        StartCoroutine(DrainNeedsOverTime());
    }

    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            healthSystem.AddValue(-healthDrainRate);
            funSystem.AddValue(-funDrainRate);
            yield return new WaitForSeconds(10f);
        }
    }
    public void BuyFood(int cost, int value)
    {
        if (moneyManager == null || foodSystem == null)
        {
            Debug.LogError("MoneyManager или FoodSystem не присвоены в инспекторе!");
            return;
        }

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
        foodSystem.AddValue(SaveData.foodCount);
        healthSystem.AddValue(SaveData.healthCount);
        funSystem.AddValue(SaveData.funCount);
        moneyManager.AddMoney(SaveData.money);

        funDrainRate = SaveData.dropFun;
        healthDrainRate = SaveData.dropHelth;

    }

    private void SaveNeeds()
    {
        SaveData.foodCount = foodSystem.GetCurrentValue();
        SaveData.healthCount = healthSystem.GetCurrentValue();
        SaveData.funCount = funSystem.GetCurrentValue();
        SaveData.money = moneyManager.GetCurrentMoney();

        SaveData.dropFun = funDrainRate;
        SaveData.money = healthDrainRate;
    }

}