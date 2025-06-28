using UnityEngine;

public class HealthButton : MonoBehaviour
{
    [SerializeField] private NeedsManager needsManager;
    [SerializeField] private int cost = 15;
    [SerializeField] private int healthValue = 25; 

    public void OnBuyHealthClick()
    {
        needsManager.BuyHealth(cost, healthValue);
    }
}