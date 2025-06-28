using UnityEngine;

public class FoodButton : MonoBehaviour
{
    [SerializeField] private NeedsManager needsManager;
    [SerializeField] private int cost = 10;
    [SerializeField] private int foodValue = 20;

    public void OnBuyFoodClick()
    {
        Debug.Log("Покупка совершена");
        needsManager.BuyFood(cost, foodValue);
    }
}