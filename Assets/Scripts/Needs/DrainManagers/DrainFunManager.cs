using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class DrainFunManager : MonoBehaviour
{
    [SerializeField] private FunSystem _funSystem;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private float _drainSpeed;
    [SerializeField] private TMP_Text _costUpgradeSpeed;
    [SerializeField] private TMP_Text _costUpgradeRate;

    [Header("������")]
    [SerializeField] private GameObject _speedUpgradeButton;
    [SerializeField] private GameObject _rateUpgradeButton;

    private int _funDrainRate;
    private int _currentCostSpeedUpgrade;
    private int _currentCostRateUpgrade;

    private bool _limited = false;

    private void Start()
    {
        _funDrainRate = SaveManager.Current.dropFun;
        _drainSpeed = SaveManager.Current.funDrainSpeed;

        _currentCostSpeedUpgrade = SaveManager.Current.costFunSpeedUpgrade;
        _currentCostRateUpgrade = SaveManager.Current.costFunRateUpgrade;

        Debug.Log(_drainSpeed + " �������� ����������");
        Debug.Log($"��������� ��������: drainSpeed={_drainSpeed}, costRate={_currentCostSpeedUpgrade}");

        UIUpdate();
        StartCoroutine(DrainNeedsOverTime());
    }

    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            _funSystem.AddValue(-_funDrainRate);
            yield return new WaitForSeconds(_drainSpeed);
        }
    }


    public void buyUpgradeSpeed()
    {
        _limited = false;
        int current = Mathf.FloorToInt(_drainSpeed);
        int cost = Mathf.FloorToInt(_currentCostSpeedUpgrade);
        Debug.Log($"������: {moneyManager.GetCurrentMoney()}, �����: {cost}");
        MinMaxCheck(14, 29, current, 1);

        if (moneyManager.TrySpendMoney(cost))
        {
            UpgradeSpeedDrain();
            UIUpdate();
        }
        else
            Debug.Log($"�� �����. ������: {moneyManager.GetCurrentMoney()}, �����: {cost}");
    }

    //��������� ������� ��������� ���������� ��� ������� ������ �� ���
    public void buyUpgradeDrain()
    {
        _limited = false;
        int cost = Mathf.FloorToInt(_currentCostRateUpgrade);
        MinMaxCheck(1, 3, _funDrainRate, 2);

        if (moneyManager.TrySpendMoney(cost) && _limited == false)
        {
            UpgradeDrainRate();
            UIUpdate();
        }
        else
            Debug.Log("�� �����");
    }

    //��������� ������� ����������� ����� �� ���������� ���������� ��� �� ��� 
    public void UpgradeSpeedDrain()
    {
        SaveManager.Current.funDrainSpeed++;
        _drainSpeed = SaveManager.Current.funDrainSpeed;
        SaveManager.Current.costFunSpeedUpgrade = (_currentCostSpeedUpgrade * 120) / 100;
        _currentCostSpeedUpgrade = SaveManager.Current.costFunSpeedUpgrade;

        Debug.Log($"����� ���������: {_currentCostRateUpgrade}");
        Debug.Log(_drainSpeed + " �������� ����������, ��������� � ������ ����� " + _currentCostSpeedUpgrade);

    }
    public void UpgradeDrainRate()
    {
        SaveManager.Current.dropFun--;
        _funDrainRate = SaveManager.Current.dropFun;
        SaveManager.Current.costFunRateUpgrade = (_currentCostRateUpgrade * 120) / 100;
        _currentCostRateUpgrade = SaveManager.Current.costFunRateUpgrade;

        Debug.Log("������ �� ��� ����������� �� " + _funDrainRate);
    }

    private void UIUpdate()
    {
        _costUpgradeRate.text = SaveManager.Current.costFunRateUpgrade.ToString();
        _costUpgradeSpeed.text = SaveManager.Current.costFunSpeedUpgrade.ToString();
        _currentCostRateUpgrade = SaveManager.Current.costFunRateUpgrade;
        _currentCostSpeedUpgrade = SaveManager.Current.costFunSpeedUpgrade;
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
        // 1 = �������� 2 = ����������
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
        Debug.Log("�����������");
    }
}
