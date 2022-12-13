using UnityEngine;

public class ResourceManager : PersistentSingleton<ResourceManager>
{
    public GoodGridItemView GoodGridItemView;
    public EditableText EditableText;

    public Sprite GetGoodsSpriteById(int goodsId)
    {
        return Resources.Load<Sprite>("Goods Pics/" + goodsId);
    }
}