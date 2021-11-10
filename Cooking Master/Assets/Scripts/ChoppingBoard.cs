using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    //is this the right chopping board or left?
    public bool leftChoppingBoard;
    //reference for items that are being chopped
    public Item itemBeingChopped;
    //reference for chopped items
    public List<Item> choppedItems;
    //does the chopping board have a combination?
    public bool hasCombination = false;

    //reference for current time chopping
    public float currentTimeChopping = 2f;


    //Called before Start
    private void Awake()
    {
        choppedItems = new List<Item>();
    }
    public void InitiateChopping(Item itemFromPlayer, bool wasBluePlayer)
    {
        StartCoroutine(ChoppingCoroutine(itemFromPlayer, wasBluePlayer));
    }
    private IEnumerator ChoppingCoroutine(Item item, bool wasBluePlayer)
    {
        itemBeingChopped = item;

        float elapsed = 0;

        while (elapsed < currentTimeChopping)
        {
            elapsed += Time.deltaTime;

            //if this is the left chopping board...
            if (leftChoppingBoard)
            {
                //...then increase the left chopping board timer
                UIManager.Instance.leftChoppingBoardTimer.fillAmount = Mathf.Lerp(1, 0, elapsed / currentTimeChopping);
            }
            //otherwise...
            else
            {
                //...increase the right one
                UIManager.Instance.rightChoppingBoardTimer.fillAmount = Mathf.Lerp(1, 0, elapsed / currentTimeChopping);
            }
            yield return null;
        }

        //if this is the left chopping board...
        if (leftChoppingBoard)
        {
            //...set the left chopping board timer to zero
            UIManager.Instance.leftChoppingBoardTimer.fillAmount = 0f;
        }
        //otherwise...
        else
        {
            //...set the right chopping board timer to zero
            UIManager.Instance.rightChoppingBoardTimer.fillAmount = 0f;
        }

        //add item that was chopped to chopped items list
        ChopItemOrCreateCombination(itemBeingChopped);
        //nullify the item being chopped variable
        itemBeingChopped = null;
        //if the blue player dropped off this item...
        if (wasBluePlayer)
        {
            //...enable the blue player's movement
            GameManager.Instance.bluePlayerRef.canMove = true;
        }
        //otherwise...
        else
        {
            //...enable the red player's movement
            GameManager.Instance.redPlayerRef.canMove = true;
        }
    }

    private void ChopItemOrCreateCombination(Item choppedItem)
    {
        switch (choppedItems.Count)
        {
            //if we have no chopped items...
            case 0:
                //...just add the chopped item
                choppedItems.Add(choppedItem);
                break;
            //or if we have one item already chopped...
            case 1:
                //...create a new item with the name itemName1+,+itemName2
                Item twoCombination = new Item(string.Format("{0},{1}", choppedItems[0].GetItemName(), choppedItem.GetItemName()), true);
                //add the new item to the chopped items
                choppedItems.Add(twoCombination);
                choppedItems.RemoveAt(0);
                //we have a combination
                hasCombination = true;
                break;
            //or if we have two items already chopped...
            case 2:
                //...create a new item with the name itemName1+,+itemName2+,+itemName3
                Item threeCombination = new Item(string.Format("{0},{1},{2}", choppedItems[0].GetItemName(), choppedItems[1].GetItemName(), choppedItem.GetItemName()), true);
                //add the new item to the chopped items
                choppedItems.Add(threeCombination);
                choppedItems.RemoveRange(0, 1);
                //we have a combination
                hasCombination = true;
                break;
        }
    }
}
