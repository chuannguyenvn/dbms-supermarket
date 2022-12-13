using UnityEngine;
using UnityEngine.Serialization;

public class ResourceManager : PersistentSingleton<ResourceManager>
{
    public GoodGridItemView GoodGridItemView;
    [FormerlySerializedAs("editableField")] [FormerlySerializedAs("EditableText")] public Field field;

    public Sprite GetGoodsSpriteById(int goodsId)
    {
        return Resources.Load<Sprite>("Goods Pics/" + goodsId);
    }
}