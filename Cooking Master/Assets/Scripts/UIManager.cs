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
            //switch statement
            switch(items.Count)
            {
                //if item count is zero...
                case 0:
                    //...run through this twice...
                    for(int i = 0; i < 2; i++)
                    {
                        //...set the blue player's inventory sprites to null
                        bluePlayerInventoryItems[i].UpdateSlot(string.Empty);
                    }
                    break;
                //if we have one item in our inventory...
                case 1:
                    //...set the first slot's sprite to the item in our list
                    bluePlayerInventoryItems[0].UpdateSlot(items[0].GetItemName());
                    bluePlayerInventoryItems[1].UpdateSlot(string.Empty);
                    break;
                //if we have two items...
                case 2:
                    //for each of the items...
                    for (int i = 0; i < items.Count; i++)
                    {
                        //...update the blue player's inventory slots with them
                        bluePlayerInventoryItems[i].UpdateSlot(items[i].GetItemName());
                    }
                    break;

            }
        }
        //otherwise...
        else
        {
            //switch statement
            switch (items.Count)
            {
                //if item count is zero...
                case 0:
                    //...run through this twice...
                    for (int i = 0; i < 2; i++)
                    {
                        //...set the red player's inventory sprites to null
                        redPlayerInventoryItems[i].UpdateSlot(string.Empty);
                    }
                    break;
                //if we have one item in our inventory...
                case 1:
                    //...set the first slot's sprite to the item in our list
                    redPlayerInventoryItems[0].UpdateSlot(items[0].GetItemName());
                    redPlayerInventoryItems[1].UpdateSlot(string.Empty);
                    break;
                //if we have two items...
                case 2:
                    //for each of the items...
                    for (int i = 0; i < items.Count; i++)
                    {
                        //...update the red player's inventory slots with them
                        redPlayerInventoryItems[i].UpdateSlot(items[i].GetItemName());
                    }
                    break;

            }
        }
    }
    public void UpdatePlayerTime(bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            //...if the blue player time UI exists...
            if(bluePlayerTimeText != null)
            {
                //...set its text as an integer of the blue player's time from Game Manager
                bluePlayerTimeText.text = string.Format("Time: {0}s", (int)GameManager.Instance.bluePlayerTime);
            }
        }
        //if we're the red player...
        else
        {
            //...if the red player time UI exists...
            if(redPlayerTimeText != null)
            {
                //...set its text as an integer of the red player's time from Game Manager
                redPlayerTimeText.text = string.Format("Time: {0}s", (int)GameManager.Instance.redPlayerTime);
            }
        }

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
