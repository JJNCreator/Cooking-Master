using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //reference for single vegetable Image
    public Image singleVegetableImage;
    //reference for double combo parent object
    public GameObject doubleComboParent;
    //reference for triple combo parent object
    public GameObject tripleComboParent;
    //reference for array of double combo images
    public Image[] doubleComboImages;
    //reference for array of triple combo images
    public Image[] tripleComboImages;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSlot(string itemName)
    {
        //local variable for comma counter
        int commaCounter = 0;
        //for each part of the item name...
        for(int i = 0; i < itemName.Length; i++)
        {
            //...if the item name contains a ','...
            if(itemName.Substring(i, 1) == ",")
            {
                //...add one to the comma counter
                commaCounter++;
            }
        }
        Debug.Log("InventorySlot:UpdateSlot() - comma counter is " + commaCounter);

        //switch statement for comma counter
        switch(commaCounter)
        {
            //we have no commas
            case 0:
                //enable only the single sprite
                ToggleSpriteGameObjects(true, false, false);
                SetSpriteForSingleImage(itemName);
                break;
            //we have one comma
            case 1:
                //enable only the double sprite
                ToggleSpriteGameObjects(false, true, false);
                SetSpritesForMultipleImages(itemName, false);
                break;
            //we have two commas
            case 2:
                //enable only the triple sprite
                ToggleSpriteGameObjects(false, false, true);
                SetSpritesForMultipleImages(itemName, true);
                break;
        }
    }
    private void SetSpriteForSingleImage(string itemName)
    {
        //set up a Sprite that is retreived from the Resources folder, using the item name
        Sprite itemSprite = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", itemName));
        //if the single image exists...
        if(singleVegetableImage != null)
        {
            //...set its sprite to the one from Resources
            singleVegetableImage.sprite = itemSprite;
        }
    }
    private void SetSpritesForMultipleImages(string itemName, bool triple)
    {
        //set up an array of strings by splitting the item name using comma
        string[] splitStrings = itemName.Split(',');
        //set up a list of strings
        List<string> listOfStrings = new List<string>();
        //for each of the strings in the array...
        foreach(string s in splitStrings)
        {
            //...add s to the list of strings
            listOfStrings.Add(s);
        }

        //for each of the strings in the list...
        for(int i = 0; i < listOfStrings.Count; i++)
        {
            //...set up a sprite that is retrieved from Resources, using s
            Sprite itemSprite = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", listOfStrings[i]));
            //set the sprites by i
            if(!triple)
            {
                doubleComboImages[i].sprite = itemSprite;
            }
            else
            {
                tripleComboImages[i].sprite = itemSprite;
            }
        }

    }

    private void ToggleSpriteGameObjects(bool singleSprite, bool doubleSprite, bool tripleSprite)
    {
        //if the single sprite exists...
        if(singleVegetableImage != null)
        {
            //...toggle it based on the boolean
            singleVegetableImage.gameObject.SetActive(singleSprite);
        }

        //if the double sprite exists...
        if(doubleComboParent != null)
        {
            //...toggle it based on the boolean
            doubleComboParent.SetActive(doubleSprite);
        }

        //if the triple sprite exists...
        if(tripleComboParent != null)
        {
            //...toggle it based on the boolean
            tripleComboParent.SetActive(tripleSprite);
        }
    }
}
