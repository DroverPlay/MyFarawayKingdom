using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeSettings
{
    public int minValue;
    public int maxValue;
    public int baseCost;
    public float costMultiplier = 1.2f;
}

public class DrainFoodManager : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private FoodSystem foodSystem;
    [SerializeField] private MoneyManager moneyManager;

    [Header("Drain Settings")]
    [SerializeField] private float drainSpeed;
    [SerializeField] private int foodDrainRate;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text costUpgradeSpeedText;
    [SerializeField] private TMP_Text costUpgradeRateText;
    [SerializeField] private Button speedUpgradeButton;
    [SerializeField] private Button rateUpgradeButton;

    [Header("Upgrade Settings")]
    [SerializeField] private UpgradeSettings speedSettings = new UpgradeSettings { minValue = 14, maxValue = 29 };
    [SerializeField] private UpgradeSettings rateSettings = new UpgradeSettings { minValue = 1, maxValue = 3 };

    private Coroutine drainCoroutine;

    private void Start()
    {
        LoadData();
        InitializeUI();
        StartDraining();
    }

    private void LoadData()
    {
        foodDrainRate = SaveManager.Current.dropFood;
        drainSpeed = SaveManager.Current.foodDrainSpeed;
    }

    private void InitializeUI()
    {
        UpdateButtonsInteractivity();
        UpdateCostTexts();
    }

    private void StartDraining()
    {
        if (drainCoroutine != null)
            StopCoroutine(drainCoroutine);

        drainCoroutine = StartCoroutine(DrainNeedsOverTime());
    }

    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            foodSystem.AddValue(-foodDrainRate);
            Debug.Log("Уменьшено");
            yield return new WaitForSeconds(drainSpeed);
        }
    }

    public void BuyUpgradeSpeed()
    {
        if (!CanUpgrade(speedSettings, drainSpeed)) return;

        int cost = CalculateUpgradeCost(speedSettings);
        if (!moneyManager.TrySpendMoney(cost)) return;

        drainSpeed++;
        SaveManager.Current.foodDrainSpeed = drainSpeed;
        SaveManager.Current.costFoodSpeedUpgrade = CalculateNextCost(speedSettings);

        ApplyUpgrade();
    }

    public void BuyUpgradeRate()
    {
        if (!CanUpgrade(rateSettings, foodDrainRate)) return;

        int cost = CalculateUpgradeCost(rateSettings);
        if (!moneyManager.TrySpendMoney(cost)) return;

        foodDrainRate--;
        SaveManager.Current.dropFood = foodDrainRate;
        SaveManager.Current.costFoodRateUpgrade = CalculateNextCost(rateSettings);

        ApplyUpgrade();
    }

    private bool CanUpgrade(UpgradeSettings settings, float currentValue)
    {
        return currentValue > settings.minValue && currentValue < settings.maxValue;
    }

    private int CalculateUpgradeCost(UpgradeSettings settings)
    {
        return Mathf.FloorToInt(settings.baseCost * Mathf.Pow(settings.costMultiplier, GetUpgradeCount(settings)));
    }

    private int CalculateNextCost(UpgradeSettings settings)
    {
        return Mathf.FloorToInt(settings.baseCost * Mathf.Pow(settings.costMultiplier, GetUpgradeCount(settings) + 1));
    }

    private int GetUpgradeCount(UpgradeSettings settings)
    {
        return settings == speedSettings ?
            (int)(drainSpeed - speedSettings.minValue) :
            (int)(rateSettings.maxValue - foodDrainRate);
    }

    private void ApplyUpgrade()
    {
        UpdateButtonsInteractivity();
        UpdateCostTexts();
    }

    private void UpdateButtonsInteractivity()
    {
        speedUpgradeButton.interactable = CanUpgrade(speedSettings, drainSpeed);
        rateUpgradeButton.interactable = CanUpgrade(rateSettings, foodDrainRate);

        speedUpgradeButton.image.color = speedUpgradeButton.interactable ? Color.white : Color.gray;
        rateUpgradeButton.image.color = rateUpgradeButton.interactable ? Color.white : Color.gray;
    }

    private void UpdateCostTexts()
    {
        costUpgradeSpeedText.text = CalculateUpgradeCost(speedSettings).ToString();
        costUpgradeRateText.text = CalculateUpgradeCost(rateSettings).ToString();
    }
}