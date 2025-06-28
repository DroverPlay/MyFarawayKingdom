using UnityEngine;

public class funButton : MonoBehaviour
{
    [SerializeField] private NeedsManager needsManager;
    [SerializeField] private int cost = 15; 
    [SerializeField] private int funValue = 25;

    public void OnBuyHealthClick()
    {
        needsManager.BuyFun(cost, funValue);
    }
}