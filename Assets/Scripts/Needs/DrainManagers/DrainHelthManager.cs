using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DrainHelthManager : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private float _drainSpeed;
    [SerializeField] private TMP_Text _costUpgradeSpeed;
    [SerializeField] private TMP_Text _costUpgradeRate;

    [Header("Кнопки")]
    [SerializeField] private GameObject _speedUpgradeButton;
    [SerializeField] private GameObject _rateUpgradeButton;

    private int _healthDrainRate;
    private int _currentCostSpeedUpgrade;
    private int _currentCostRateUpgrade;

    private bool _limited = false;

    private void Start()
    {
        _healthDrainRate = SaveManager.Current.dropHealth;
        _drainSpeed = SaveManager.Current.healthDrainSpeed;

        _currentCostSpeedUpgrade = SaveManager.Current.costHealthSpeedUpgrade;
        _currentCostRateUpgrade = SaveManager.Current.costHealthRateUpgrade;

        Debug.Log(_drainSpeed + " Скорость уменьшения");
        Debug.Log($"Стартовые значения: drainSpeed={_drainSpeed}, costRate={_currentCostSpeedUpgrade}");

        UIUpdate();
        StartCoroutine(DrainNeedsOverTime());
    }

    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            _healthSystem.AddValue(-_healthDrainRate);
            yield return new WaitForSeconds(_drainSpeed);
        }
    }


    public void buyUpgradeSpeed()
    {
        _limited = false;
        int current = Mathf.FloorToInt(_drainSpeed);
        int cost = Mathf.FloorToInt(_currentCostSpeedUpgrade);
        Debug.Log($"Деньги: {moneyManager.GetCurrentMoney()}, Нужно: {cost}");
        MinMaxCheck(14, 29, current, 1);

        if (moneyManager.TrySpendMoney(cost))
        {
            UpgradeSpeedDrain();
            UIUpdate();
        }
        else
            Debug.Log($"Не купил. Деньги: {moneyManager.GetCurrentMoney()}, Нужно: {cost}");
    }

    //Улучшение которое уменьшает количетсво еды которое уходит за раз
    public void buyUpgradeDrain()
    {
        _limited = false;
        int cost = Mathf.FloorToInt(_currentCostRateUpgrade);
        MinMaxCheck(1, 3, _healthDrainRate, 2);

        if (moneyManager.TrySpendMoney(cost) && _limited == false)
        {
            UpgradeDrainRate();
            UIUpdate();
        }
        else
            Debug.Log("Не купил");
    }

    //Улучшение которое увеличивает время на уменьшение количества еды за раз 
    public void UpgradeSpeedDrain()
    {
        SaveManager.Current.healthDrainSpeed++;
        _drainSpeed = SaveManager.Current.healthDrainSpeed;
        SaveManager.Current.costHealthSpeedUpgrade = (_currentCostSpeedUpgrade * 120) / 100;
        _currentCostSpeedUpgrade = SaveManager.Current.costHealthSpeedUpgrade;

        Debug.Log($"Новая стоимость: {_currentCostRateUpgrade}");
        Debug.Log(_drainSpeed + " Скорость уменьшения, прокачана и теперь стоит " + _currentCostSpeedUpgrade);

    }
    public void UpgradeDrainRate()
    {
        SaveManager.Current.dropHealth--;
        _healthDrainRate = SaveManager.Current.dropHealth;
        SaveManager.Current.costHealthRateUpgrade = (_currentCostRateUpgrade * 120) / 100;
        _currentCostRateUpgrade = SaveManager.Current.costHealthRateUpgrade;

        Debug.Log("Теперь за раз уменьшается на " + _healthDrainRate);
    }

    private void UIUpdate()
    {
        _costUpgradeRate.text = SaveManager.Current.costHealthRateUpgrade.ToString();
        _costUpgradeSpeed.text = SaveManager.Current.costHealthSpeedUpgrade.ToString();
        _currentCostRateUpgrade = SaveManager.Current.costHealthRateUpgrade;
        _currentCostSpeedUpgrade = SaveManager.Current.costHealthSpeedUpgrade;
    }

    private void MinMaxCheck(int min, int max, int current, int var)
    {
        if (current <= min || current >= max)
        {
            UnclickButton(var);
            _limited = true;
        }
        else
            _limited = false;
    }

    private void UnclickButton(int var)
    {
        // 1 = скорость 2 = количество
        if (var == 1)
        {
            _speedUpgradeButton.gameObject.GetComponent<Image>().color = Color.gray;
            _speedUpgradeButton.gameObject.GetComponent<Button>().interactable = false;
        }
        if (var == 2)
        {
            _rateUpgradeButton.gameObject.GetComponent<Image>().color = Color.gray;
            _rateUpgradeButton.gameObject.GetComponent<Button>().interactable = false;
        }
        Debug.Log("Исполняется");
    }
}
