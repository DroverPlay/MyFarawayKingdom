using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NeedsSystem : MonoBehaviour
{
    [Header("Слайдеры и тексты")]
    [SerializeField] protected Image slider;
    [SerializeField] protected TMP_Text countText;

    protected int currentValue;

    public virtual void AddValue(int value)
    {
        currentValue += value;
        currentValue = Mathf.Clamp(currentValue, 0, 100);
        UpdateUI();
    }

    protected void UpdateUI()
    {
        slider.fillAmount = currentValue / 100f;
        countText.text = currentValue.ToString();
    }

    public int GetCurrentValue() => currentValue;
}