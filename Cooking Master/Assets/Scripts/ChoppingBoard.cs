using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    //reference for items that are being chopped
    public Item itemBeingChopped;
    //reference for chopped items
    public List<Item> choppedItems;

    //reference for current time chopping
    public float currentTimeChopping = 4f;


    //Called before Start
    private void Awake()
    {
        choppedItems = new List<Item>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitiateChopping(Item itemFromPlayer, bool wasBluePlayer)
    {
        StartCoroutine(ChoppingCoroutine(itemFromPlayer, wasBluePlayer));
    }
    private IEnumerator ChoppingCoroutine(Item item, bool wasBluePlayer)
    {
        itemBeingChopped = item;
        yield return new WaitForSeconds(currentTimeChopping);
        //add item that was chopped to chopped items list
        choppedItems.Add(itemBeingChopped);
        //nullify the item being chopped variable
        itemBeingChopped = null;
        //if the blue player dropped off this item...
        if(wasBluePlayer)
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
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
