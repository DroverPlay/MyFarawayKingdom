using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private NeedsManager needsManager;
    [Header("1-еда 2-веселье 3-здоровье")]
    [SerializeField] private int type;

    private void Awake()
    {
        GameObject _moneyManager = new GameObject();
        _moneyManager = GameObject.FindGameObjectWithTag("MoneyManager");
        needsManager = _moneyManager.GetComponent<NeedsManager>();
    }
    public void Setup(ProductData product)
    {
        iconImage.sprite = product.icon;
        nameText.text = product.name;
        priceText.text = $"{product.price}";

        GetComponent<Button>().onClick.AddListener(() => BuyProduct(product));
    }

    private void BuyProduct(ProductData product)
    {
        Debug.Log($"Куплен товар: {product.name}");
        int cost = product.price;
        if (type == 1)
            needsManager.BuyFood(product.price, product.value);
        if (type == 2)
            needsManager.BuyFun(product.price, product.value);
        if(type == 3)
            needsManager.BuyHealth(product.price, product.value);
    }
}