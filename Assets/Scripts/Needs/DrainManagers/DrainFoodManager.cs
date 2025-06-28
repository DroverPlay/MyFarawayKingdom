using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DrainFoodManager : MonoBehaviour
{
    [SerializeField] private FoodSystem _foodSystem;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private float _drainSpeed;
    [SerializeField] private TMP_Text _costUpgradeSpeed;
    [SerializeField] private TMP_Text _costUpgradeRate;


    private int foodDrainRate;
    private int _currentCostSpeedUpgrade;
    private int _currentCostRateUpgrade;

    private void Start()
    {
        foodDrainRate = SaveData.dropFood;
        _drainSpeed = SaveData.drainFoodSpeedCount;

        _currentCostSpeedUpgrade = SaveData.CostFoodSpeedUpgrade;
        _currentCostRateUpgrade = SaveData.CostFoodRateUpgrade;

        Debug.Log(_drainSpeed + " Скорость уменьшения");
        Debug.Log($"Стартовые значения: drainSpeed={_drainSpeed}, costRate={_currentCostSpeedUpgrade}");

        UIUpdate();
        StartCoroutine(DrainNeedsOverTime());
    }

    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            _foodSystem.AddValue(-foodDrainRate);
            yield return new WaitForSeconds(_drainSpeed);
        }
    }


    public void buyUpgradeSpeed()
    {
        int cost = Mathf.FloorToInt(_currentCostSpeedUpgrade);
        Debug.Log($"Деньги: {moneyManager.GetCurrentMoney()}, Нужно: {cost}");

        if (moneyManager.TrySpendMoney(cost))
        {
            UpgradeSpeedDrain();
            UIUpdate();
        }
        else
            Debug.Log($"Не купил. Деньги: {moneyManager.GetCurrentMoney()}, Нужно: {cost}");
    }

    public void buyUpgradeDrain()
    {
        int cost = Mathf.FloorToInt(_currentCostRateUpgrade);

        if (moneyManager.TrySpendMoney(cost))
        {
            UpgradeDrainRate();
            UIUpdate();
        }
        else
            Debug.Log("Не купил");
    }

    public void UpgradeSpeedDrain()
    {
        SaveData.drainFoodSpeedCount++;
        _drainSpeed = SaveData.drainFoodSpeedCount;
        SaveData.CostFoodSpeedUpgrade = (_currentCostSpeedUpgrade * 120) / 100;
        _currentCostSpeedUpgrade = SaveData.CostFoodSpeedUpgrade;

        Debug.Log($"Новая стоимость: {_currentCostRateUpgrade}");
        Debug.Log(_drainSpeed + " Скорость уменьшения, прокачана и теперь стоит " + _currentCostSpeedUpgrade);

    }
    public void UpgradeDrainRate()
    {
        SaveData.dropFood--;
        foodDrainRate = SaveData.dropFood;
        SaveData.CostFoodRateUpgrade = (_currentCostRateUpgrade * 120) / 100;
        _currentCostRateUpgrade = SaveData.CostFoodRateUpgrade;

        Debug.Log("Теперь за раз уменьшается на " + foodDrainRate);
    }

    private void UIUpdate()
    {
        _costUpgradeRate.text = SaveData.CostFoodRateUpgrade.ToString();
        _costUpgradeSpeed.text = SaveData.CostFoodSpeedUpgrade.ToString();
        _currentCostRateUpgrade = SaveData.CostFoodRateUpgrade;
        _currentCostSpeedUpgrade = SaveData.CostFoodSpeedUpgrade;
    }
}
