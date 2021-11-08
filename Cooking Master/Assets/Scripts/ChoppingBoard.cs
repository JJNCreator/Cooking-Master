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

        float elapsed = 0;

        while(elapsed < currentTimeChopping)
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
        if(leftChoppingBoard)
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
