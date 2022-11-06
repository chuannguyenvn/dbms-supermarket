using UnityEngine;

[CreateAssetMenu(menuName = "Product", fileName = "Product")]
public class Product : ScriptableObject
{
    public string Name;
    public int Price;
    [TextArea(10, 10)] public string Description;
    public ProductType ProductType;
    public Sprite Sprite;
}

public enum ProductType
{
    Uncategorized,
    Food_and_Beverages,
    Medicine,
    Electrical_devices,
    Toys,
    Clothes,
}