using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemTableMaster", menuName = "Items/New ItemTableMaster")]
public class ItemTableMaster : ScriptableObject
{
    [SerializeField]
    List<Item> itemTable;

    public Item GetItem(int ID) { return  itemTable[ID]; }

    public void AssignItemIDs()
    {
        for (int i = 0; i < itemTable.Count; i++)
        {
            try { itemTable[i].ItemID = i; }
            catch(ItemModifiedException) { }
        }
    }
}
