using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class NeedsManager : MonoBehaviour
{
    [Header("Основы")]
    [SerializeField] TMP_Text moneyCountText;
    [Header("Еда")]
    [SerializeField] Image foodSlider;
    [SerializeField] TMP_Text foodCountText;
    [Header("Здоровье")]
    [SerializeField] Image helthSlider;
    [SerializeField] TMP_Text helthCountText;
    [Header("Веселье")]
    [SerializeField] Image funSlider;
    [SerializeField] TMP_Text funCountText;
    [Header("Тип")]
    [SerializeField] bool isFood;
    [SerializeField] bool isHealth;
    [SerializeField] bool isFun;

    public int foodCount;
    public float _add;
    private bool isBuy;

    //private void Awake()
    //{
        //Load();
        //if (SaveData.foodCount > 0)
        //{
        //    moneyCountText.text = SaveData.money.ToString();
        //    foodCountText.text = SaveData.foodCount.ToString();
        //    helthCountText.text = SaveData.healthCount.ToString();
        //    funCountText.text = SaveData.funCount.ToString();
        //}
    //}

    //private void Start()
    //{
    //    if (SaveData.foodCount > 0)
    //    {
    //        moneyCountText.text = SaveData.money.ToString();

    //        if (isFood)
    //        {
    //            foodCountText.text = SaveData.foodCount.ToString();
    //        }
    //        if (isHealth)
    //        {
    //            foodCountText.text = SaveData.healthCount.ToString();
    //        }
    //        if (isFun)
    //        {
    //            foodCountText.text = SaveData.healthCount.ToString();
    //        }
    //    }
    //}
    public void addfood(int add)
    {
        if (isBuy)
        {
            if (isFood)
            {
                addNeeds(add, foodSlider, foodCountText);
                Debug.Log("Это еда :" + SaveData.foodCount);
            }
            if (isHealth)
            {
                addNeeds(add, helthSlider, helthCountText);
                Debug.Log("Это здоровье :" + SaveData.healthCount);
            }
            if (isFun)
            {
                addNeeds(add, funSlider, funCountText);
                Debug.Log("Это веселье :" + SaveData.funCount);
            }
        }
    }

    public void addNeeds(int add, Image slider, TMP_Text text)
    {
        _add = add / 100f;
        //Debug.Log(_add);
        slider.fillAmount += _add;
        foodCount = Convert.ToInt32(text.text);
        foodCount += add;
        text.text = foodCount.ToString();
        if (Convert.ToInt32(foodCountText.text) > 100)
        {
            foodCountText.text = 100.ToString();;
        }
        if (Convert.ToInt32(helthCountText.text) > 100)
        {
            helthCountText.text = 100.ToString();
        }
        if (Convert.ToInt32(funCountText.text) > 100)
        {
            funCountText.text = 100.ToString();
        }
        isBuy = false;
    }

    public void checkMoney(int needMoney)
    {
        int moneyCount = Convert.ToInt32(moneyCountText.text);
        if (moneyCount >= needMoney)
        {
            if (Convert.ToInt32(foodCountText.text) < 100)
            {
                isBuy = true;
                moneyCountText.text = Convert.ToString(moneyCount - needMoney);
            }
            if (Convert.ToInt32(helthCountText.text) < 100)
            {
                isBuy = true;
                moneyCountText.text = Convert.ToString(moneyCount - needMoney);
            }
            if (Convert.ToInt32(funCountText.text) < 100)
            {
                isBuy = true;
                moneyCountText.text = Convert.ToString(moneyCount - needMoney);
            }
        }
        else
            isBuy = false;
        SaveData.money = moneyCount;
        Debug.Log("Количество денег:" + SaveData.money);
        Debug.Log(isBuy);
    }

    public void Save()
    {
        SaveData.foodCount = Convert.ToInt32(foodCountText.text);
        SaveData.healthCount = Convert.ToInt32(helthCountText.text);
        SaveData.funCount = Convert.ToInt32(funCountText.text);
        SaveData.money = Convert.ToInt32(moneyCountText.text);
        Debug.Log("Сохранено");
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

        Debug.Log("Загружено");
    }
}
