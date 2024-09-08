using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class NeedsManager : MonoBehaviour
{
    [Header("������")]
    [SerializeField] Image foodSlider;
    [SerializeField] TMP_Text foodCountText;
    [SerializeField] TMP_Text moneyCountText;
    [Header("���")]
    [SerializeField] bool isFood;
    [SerializeField] bool isHealth;
    [SerializeField] bool isFun;

    public int foodCount;
    public float _add;
    private bool isBuy;

    public void addfood(int add)
    {
        if (isBuy)
        {
            _add = add / 100f;
            //Debug.Log(_add);
            foodSlider.fillAmount += _add;
            foodCount = Convert.ToInt32(foodCountText.text);
            foodCount += add;
            foodCountText.text = foodCount.ToString();
            if (Convert.ToInt32(foodCountText.text) > 100)
            {
                foodCountText.text = 100.ToString();
                foodCount = 100;
            }
            isBuy = false;
            if (isFood) 
            {
                SaveData.foodCount = foodCount;
                Debug.Log("��� ��� :" + SaveData.foodCount);
            }
            if (isHealth)
            {
                SaveData.healthCount = foodCount;
                Debug.Log("��� �������� :" + SaveData.healthCount);
            }
            if (isFun)
            {
                SaveData.funCount = foodCount;
                Debug.Log("��� ������� :" + SaveData.funCount);
            }

        }
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
        }
        else
            isBuy = false;
        SaveData.money = moneyCount;
        Debug.Log("���������� �����:" + SaveData.money);
        Debug.Log(isBuy);
    }
}
