using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEditor;

public class NeedsManager : MonoBehaviour
{
    [Header("Текста")]
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
            Save(); // Сохраняем изменения
            yield return new WaitForSeconds(1f); // 1 минута
        }
    }
    public void dropValue(int value)
    {
        addNeeds(value, foodSlider, foodCountText);
        addNeeds(value, helthSlider, helthCountText);
        addNeeds(value, funSlider, funCountText);
    }

    public void addfood(int add)
    {
        if (isBuy)
        {
            if (isFood)
            {
                addNeeds(add, foodSlider, foodCountText);
            }
            if (isHealth)
            {
                addNeeds(add, helthSlider, helthCountText);
            }
            if (isFun)
            {
                addNeeds(add, funSlider, funCountText);
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
        maxMinCheck(foodCountText);
        maxMinCheck(helthCountText);
        maxMinCheck(funCountText); 
        isBuy = false;
    }
    

    public void checkMoney(int needMoney)
    {
        int moneyCount = Convert.ToInt32(moneyCountText.text);
        if (moneyCount >= needMoney)
        {
            if (Convert.ToInt32(foodCountText.text) < 100)
            {
                IsBuy(moneyCount, needMoney);
            }
            if (Convert.ToInt32(helthCountText.text) < 100)
            {
                IsBuy(moneyCount, needMoney);
            }
            if (Convert.ToInt32(funCountText.text) < 100)
            {
                IsBuy(moneyCount, needMoney);
            }
        }
        else
            isBuy = false;

        moneyCount = Convert.ToInt32(moneyCountText.text);
        SaveData.money = moneyCount;
        Debug.Log(isBuy);
    }

    private void IsBuy(int money, int needMoneys)
    {
        isBuy = true;
        moneyCountText.text = Convert.ToString(money - needMoneys);
    }
    private void maxMinCheck(TMP_Text text)
    {
        if (Convert.ToInt32(text.text) > 100)
        { text.text = 100.ToString(); }
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