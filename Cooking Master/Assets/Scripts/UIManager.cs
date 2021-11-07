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

    //reference for endgame UI
    public GameObject endUI;

    //reference for blue player inventory items
    public Image[] bluePlayerInventoryItems;
    //reference for red player inventory items
    public Image[] redPlayerInventoryItems;

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
        //store the original material
        originalInventoryItemMaterial = bluePlayerInventoryItems[0].material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerInventory(List<Item> items, bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            if(items.Count > 0)
            {
                //...forloop for each of the items...
                for (int i = 0; i < items.Count; i++)
                {
                    //...set up a material local variable that's assigned to the item's material based on it's name
                    Material vegetableMaterial = GameManager.Instance.vegetableMaterialsSo.GetVegetableMaterial(items[i].GetItemName());
                    //assign the material to each of the UI images
                    bluePlayerInventoryItems[i].material = vegetableMaterial;
                }
            }
            else if (items.Count == 0)
            {
                for(int i = 0; i < bluePlayerInventoryItems.Length; i++)
                {
                    bluePlayerInventoryItems[i].material = originalInventoryItemMaterial;
                }
            }
        }
        //otherwise...
        else
        {
            if(items.Count > 0)
            {
                //...forloop for each of the items...
                for (int i = 0; i < items.Count; i++)
                {
                    //...set up a material local variable that's assigned to the item's material based on it's name
                    Material vegetableMaterial = GameManager.Instance.vegetableMaterialsSo.GetVegetableMaterial(items[i].GetItemName());
                    //assign the material to each of the UI images
                    redPlayerInventoryItems[i].material = vegetableMaterial;
                }
            }
            else if (items.Count == 0)
            {
                for (int i = 0; i < redPlayerInventoryItems.Length; i++)
                {
                    redPlayerInventoryItems[i].material = originalInventoryItemMaterial;
                }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
