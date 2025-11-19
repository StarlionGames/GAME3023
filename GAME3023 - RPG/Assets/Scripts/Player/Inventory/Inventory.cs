using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    public void AddToInventory(Item item, int number)
    {
        if (itemSlots.Count == 0)
        {
            itemSlots.Add(new ItemSlot(item, number));
        }
    }
}
