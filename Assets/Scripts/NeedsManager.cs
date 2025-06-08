using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;

public class NeedsManager : MonoBehaviour
{
    [Header("Основные объекты")]
    [SerializeField] TMP_Text moneyCountText;
    [Header("Еда")]
    [SerializeField] Image foodSlider;
    [SerializeField] TMP_Text foodCountText;
    [Header("Медицина")]
    [SerializeField] Image helthSlider;
    [SerializeField] TMP_Text helthCountText;
    [Header("Веселье")]
    [SerializeField] Image funSlider;
    [SerializeField] TMP_Text funCountText;
    [Header("Вид")]
    [SerializeField] bool isFood;
    [SerializeField] bool isHealth;
    [SerializeField] bool isFun;
    [SerializeField] bool isDrop;

    public int foodCount;
    public float _add;
    private bool isBuy;
    private int _needMoney;
  
    private void Start()
    {
        Time.timeScale = 1.0f;
        Load();
        if (isDrop)
            StartCoroutine(DrainNeedsOverTime());
    }
    private IEnumerator DrainNeedsOverTime()
    {
        while (true)
        {
            dropValue(-1);
            Save();
            yield return new WaitForSeconds(10f); 
        }
    }
    public void dropValue(int value)
    {
        addNeeds(value, foodSlider, foodCountText, 0);
        addNeeds(value, helthSlider, helthCountText, 0);
        addNeeds(value, funSlider, funCountText, 0);
    }
    public void addfood(int add)
    {
        if (isBuy)
        {
            if (isFood && Convert.ToInt32(foodCountText.text) < 100)
            {
                addNeeds(add, foodSlider, foodCountText,_needMoney);
                isBuy = false;
            }
            else if (isHealth && Convert.ToInt32(helthCountText.text) < 100)
            {
                addNeeds(add, helthSlider, helthCountText, _needMoney);
                isBuy = false;
            }
            else if (isFun && Convert.ToInt32(funCountText.text) < 100)
            {
                addNeeds(add, funSlider, funCountText, _needMoney);
                isBuy = false;
            }
            Save();
        }
    }
    public void addNeeds(int add, Image slider, TMP_Text text, int needMoney)
    {
        int currentMoney = Convert.ToInt32(moneyCountText.text);
        currentMoney -= needMoney;
        moneyCountText.text = currentMoney.ToString();
        _add = add / 100f;
        slider.fillAmount += _add;
        foodCount = Convert.ToInt32(text.text);
        foodCount += add;
        text.text = foodCount.ToString();
        MaxMinCheck(foodCountText);
        MaxMinCheck(helthCountText);
        MaxMinCheck(funCountText); 
        isBuy = false;
    }
    public void CheckMoney(int money)
    {
        int currentMoney = Convert.ToInt32(moneyCountText.text);
        _needMoney = money;
        if (currentMoney >= money)
        {
            isBuy = true;
        }
    }
    static private void MaxMinCheck(TMP_Text text)
    {
        if (Convert.ToInt32(text.text) >= 100)
        { text.text = 100.ToString();}
        if (Convert.ToInt32(text.text) < 0)
        { text.text = 0.ToString(); }
    }
    public void Save()
    {
        SaveData.foodCount = Convert.ToInt32(foodCountText.text);
        SaveData.healthCount = Convert.ToInt32(helthCountText.text);
        SaveData.funCount = Convert.ToInt32(funCountText.text);
        SaveData.money = Convert.ToInt32(moneyCountText.text);
    }
    public void Load()
    {
        foodSlider.fillAmount = SaveData.foodCount / 100f;
        foodCountText.text = SaveData.foodCount.ToString();

        helthSlider.fillAmount = SaveData.healthCount / 100f;
        helthCountText.text = SaveData.healthCount.ToString();

        funSlider.fillAmount = SaveData.funCount / 100f;
        funCountText.text = SaveData.funCount.ToString();

        moneyCountText.text = SaveData.money.ToString();
    }
}