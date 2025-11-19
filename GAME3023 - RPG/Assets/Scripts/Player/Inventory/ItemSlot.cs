using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item ItemInSlot;
    public int ItemCount;

    public ItemSlot(Item _item, int _count)
    {
        ItemInSlot = _item;
        ItemCount = _count;
    }
}
