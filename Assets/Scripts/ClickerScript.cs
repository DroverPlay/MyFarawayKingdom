using System;
using UnityEngine;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    int money;
    bool holdButton_b;
    [Header("Основы")]
    [SerializeField] TMP_Text money_text;
    [SerializeField] NeedsManager need_manager;

    private void Start()
    {
        need_manager.Load();
        InvokeRepeating("CheckHold", 0f, 0.5f);
    }
    public void Click_Button()
    {
        int current_money = Convert.ToInt32(money_text.text);
        current_money++;
        money_text.text = current_money.ToString();
    }
    public void HoldButton(bool hoold)
    {
        holdButton_b = hoold;
    }
    void CheckHold()
    {
        if (holdButton_b)
        {
            Click_Button();
        }
    }
}
