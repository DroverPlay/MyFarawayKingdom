using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ProductDatabase productDB;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonsParent;

    private void Start()
    {
        CreateProductButtons();
    }

    private void CreateProductButtons()
    {
        foreach (ProductData product in productDB.products)
        {
            GameObject button = Instantiate(buttonPrefab, buttonsParent);
            ProductButton productBtn = button.GetComponent<ProductButton>();

            productBtn.Setup(product);
        }
    }
}