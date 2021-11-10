using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    //reference for item name
    [SerializeField] private string itemName;
    //reference for whether this item is a combination
    [SerializeField] private bool isCombination;

    public Item(string n, bool c)
    {
        itemName = n;
        isCombination = c;
    }
    public string GetItemName()
    {
        //return item name
        return itemName;
    }
    public bool IsCombination()
    {
        //return combination value
        return isCombination;
    }
    public static Item EmptyItem()
    {
        return new Item(string.Empty, false);
    }
}
