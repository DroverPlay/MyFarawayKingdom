using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    [Header("Основные объекты")]
    [SerializeField] private TMP_Text _money_text;
    [Header("Настройки нажатий")]
    [SerializeField] private float _clickDelay = 0.1f;

    private int _money;
    private bool _isHolding;
    private float _lastClickTime;

    private void Awake()
    {
        //_money = SaveManager.Current.money;
        StartCoroutine(HoldClickCoroutine());

        Image image = GetComponent<Image>();
        if (image != null)
            image.alphaHitTestMinimumThreshold = 0.1f;

    }
    public void ClickButton()
    {
        if (Time.time - _lastClickTime < _clickDelay)
            return;

        _lastClickTime = Time.time;
        _money = SaveManager.Current.money;
        _money ++;
        UpdateMoneyText();
    }
    public void SetHold(bool isHolding)
    {
        _isHolding = isHolding;
    }
    private IEnumerator HoldClickCoroutine()
    {
        while (true)
        {
            if (_isHolding)
            {
                ClickButton();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void UpdateMoneyText()
    {
        _money_text.text = _money.ToString();
        SaveManager.Current.money = _money;
    }
}
