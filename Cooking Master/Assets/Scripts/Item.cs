using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    //reference for item name
    [SerializeField]private string itemName;

    public Item(string n)
    {
        itemName = n;
    }
    public string GetItemName()
    {
        //return item name
        return itemName;
    }
}
