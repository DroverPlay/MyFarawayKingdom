using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    [Header("Основы")]
    [SerializeField] TMP_Text money_text;
    [SerializeField] NeedsManager need_manager;
    [Header("Клики")]
    [SerializeField] private float _clickDelay = 0.1f;

    private int _money;
    private bool _isHolding;
    private float _lastClickTime;

    //private void Start()
    //{
    //    need_manager.Load();
    //    StartCoroutine(HoldClickCoroutine());

    //    Image image = GetComponent<Image>();
    //    if (image != null)
    //        image.alphaHitTestMinimumThreshold = 0.1f;

    //}
    private void Awake()
    {
        _money = SaveData.money;
        //need_manager.Load();
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
        _money++;
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
        money_text.text = _money.ToString();
    }
}
