using UnityEngine;

[CreateAssetMenu(fileName = "ProductDatabase", menuName = "Shop/Product Database")]
public class ProductDatabase : ScriptableObject
{
    public ProductData[] products;
}