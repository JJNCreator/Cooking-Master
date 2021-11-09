using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //reference for blue player time UI
    public Text bluePlayerTimeText;
    //reference for blue player score UI
    public Text bluePlayerScoreText;
    //reference for red player time UI
    public Text redPlayerTimeText;
    //reference for red player score UI
    public Text redPlayerScoreText;

    //reference for left chopping board timer UI
    public Image leftChoppingBoardTimer;
    //referene for right chopping board timer UI
    public Image rightChoppingBoardTimer;

    //reference for endgame UI
    public GameObject endUI;

    //reference for blue player inventory items
    public InventorySlot[] bluePlayerInventoryItems;
    //reference for red player inventory items
    public InventorySlot[] redPlayerInventoryItems;

    //reference for original inventory items material
    private Material originalInventoryItemMaterial;


    //reference for instance getter
    private static UIManager instance;

    //instance for this class
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    public void UpdatePlayerInventory(List<Item> items, bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            //for each of the items...
            for(int i = 0; i < items.Count; i++)
            {
                //...update the blue player's inventory slots with them
                bluePlayerInventoryItems[i].UpdateSlot(items[i].GetItemName());
            }
        }
        //otherwise...
        else
        {
            //for each of the items...
            for (int i = 0; i < items.Count; i++)
            {
                //...update the blue player's inventory slots with them
                redPlayerInventoryItems[i].UpdateSlot(items[i].GetItemName());
            }
        }

        /*//if we're the blue player...
        if (bluePlayer)
        {
            //...switch statement
            switch(items.Count)
            {
                //if we don't have anything in our inventory...
                case 0:
                    //...run through this twice
                    for(int i = 0; i < 2; i++)
                    {
                        //...set both inventory items' sprite to null
                        bluePlayerInventoryItems[i].sprite = null;
                    }
                    break;
                //if we have one item in our inventory...
                case 1:
                    //set up a new string that is empty
                    string singleOrCombinationName = string.Empty;
                    //if the item is a combination
                    if (items[0].IsCombination())
                    {
                        //...set up an array of strings that is split by the coma in the first item name
                        string[] splitStrings = items[0].GetItemName().Split(',');
                        //for each of the values in the array...
                        foreach(string s in splitStrings)
                        {
                            //...add s to the empty string
                            singleOrCombinationName += s;
                        }
                    }
                    //if the item is not a combination...
                    else
                    {
                        //...just assign the item name to combinationWithoutComas
                        singleOrCombinationName = items[0].GetItemName();
                    }
                    //set up a sprite that is retrieved from the Resources folder based on the combination without comas
                    Sprite itemSprite = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", singleOrCombinationName));
                    //assign the sprite to the first slot in the player's inventory
                    bluePlayerInventoryItems[0].sprite = itemSprite;
                    break;
                //if we have two items in our inventory...
                case 2:
                    //set up a string that is empty
                    string singleOrCombinationName2 = string.Empty;
                    //...for each of the items in the input parameter...
                    for(int i = 0; i < items.Count; i++)
                    {
                        //...if items[i] is a combination...
                        if(items[i].IsCombination())
                        {
                            //...set up an array of strings that is split by the coma in items[i]
                            string[] splitStrings2 = items[i].GetItemName().Split(',');
                            //for each of the values in the array...
                            foreach(string s2 in splitStrings2)
                            {
                                //...add s to the empty string
                                singleOrCombinationName2 += s2;
                            }
                        }
                        //if the item is not a combination...
                        else
                        {
                            //...just assign the item name to combinationWithoutComas
                            singleOrCombinationName2 = items[i].GetItemName();
                        }
                        //set up a sprite that is retrieved from ther Resources folder based on item[i]'s name
                        Sprite itemSprite2 = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", singleOrCombinationName2));
                        //assign the sprite to the slots of the player inventory
                        bluePlayerInventoryItems[i].sprite = itemSprite2;
                    }
                    break;
            }
        }
        //if we're the red player...
        else
        {
            //...switch statement
            switch (items.Count)
            {
                //if we don't have anything in our inventory...
                case 0:
                    //...run through this twice
                    for (int i = 0; i < 2; i++)
                    {
                        //...set both inventory items' sprite to null
                        redPlayerInventoryItems[i].sprite = null;
                    }
                    break;
                //if we have one item in our inventory...
                case 1:
                    //set up a new string that is empty
                    string singleOrCombinationName = string.Empty;
                    //if the item is a combination
                    if (items[0].IsCombination())
                    {
                        //...set up an array of strings that is split by the coma in the first item name
                        string[] splitStrings = items[0].GetItemName().Split(',');
                        //for each of the values in the array...
                        foreach (string s in splitStrings)
                        {
                            //...add s to the empty string
                            singleOrCombinationName += s;
                        }
                    }
                    //if the item is not a combination...
                    else
                    {
                        //...just assign the item name to combinationWithoutComas
                        singleOrCombinationName = items[0].GetItemName();
                    }
                    //set up a sprite that is retrieved from the Resources folder based on the combination without comas
                    Sprite itemSprite = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", singleOrCombinationName));
                    //assign the sprite to the first slot in the player's inventory
                    redPlayerInventoryItems[0].sprite = itemSprite;
                    break;
                //if we have two items in our inventory...
                case 2:
                    //set up a string that is empty
                    string singleOrCombinationName2 = string.Empty;
                    //...for each of the items in the input parameter...
                    for (int i = 0; i < items.Count; i++)
                    {
                        //...if items[i] is a combination...
                        if (items[i].IsCombination())
                        {
                            //...set up an array of strings that is split by the coma in items[i]
                            string[] splitStrings2 = items[i].GetItemName().Split(',');
                            //for each of the values in the array...
                            foreach (string s2 in splitStrings2)
                            {
                                //...add s to the empty string
                                singleOrCombinationName2 += s2;
                            }
                        }
                        //if the item is not a combination...
                        else
                        {
                            //...just assign the item name to combinationWithoutComas
                            singleOrCombinationName2 = items[i].GetItemName();
                        }
                        //set up a sprite that is retrieved from ther Resources folder based on item[i]'s name
                        Sprite itemSprite2 = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", singleOrCombinationName2));
                        //assign the sprite to the slots of the player inventory
                        redPlayerInventoryItems[i].sprite = itemSprite2;
                    }
                    break;
            }
        }*/
    }
    public void UpdatePlayerScore(int newScore, bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            //...set the text of the blue player score to say Score: newScore
            if(bluePlayerScoreText != null)
            {
                bluePlayerScoreText.text = string.Format("Score: {0}", newScore.ToString());
            }
        }
        //otherwise...
        else
        {
            //...set the text of the red player score to say Score: newScore
            if(redPlayerScoreText != null)
            {
                redPlayerScoreText.text = string.Format("Score: {0}", newScore.ToString());
            }
        }
    }
    public void RestartGame()
    {
        //Load the scene we're currently in, effectively reloads this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
