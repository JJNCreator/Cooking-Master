using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Speed,
        Time,
        Score
    }
    //reference for pickup type
    public PickupType type;
    //can this item only be picked up by the blue player or red player?
    public bool canBePickedUpByBluePlayer;
    //has the player picked up this item?
    private bool hasPickedUpItem = false;
   
    private void InitiateAbility(bool bluePlayer)
    {
        //set the player character for this initiation to blue
        PlayerCharacter player = GameManager.Instance.bluePlayerRef;
        //if we're the red player...
        if(!bluePlayer)
        {
            //...set the player character to red
            player = GameManager.Instance.redPlayerRef;
        }

        //switch statement for the pickup type
        switch(type)
        {
            //Speed
            case PickupType.Speed:
                StartCoroutine(IncreasePlayerSpeedTemporarily(player));
                hasPickedUpItem = true;
                GetComponentInChildren<Renderer>().enabled = false;
                break;
            //Time
            case PickupType.Time:
                //if we're the blue player...
                if(bluePlayer)
                {
                    //...increase the blue player's time
                    GameManager.Instance.bluePlayerTime += 20f;
                }
                //if we're the red player...
                else
                {
                    //...increase the red player's time
                    GameManager.Instance.redPlayerTime += 20f;
                }
                //Destroy this object
                Destroy(this.gameObject);
                break;
            //Score
            case PickupType.Score:
                GameManager.Instance.UpdatePlayerScore(+20, bluePlayer);
                //Destroy this object
                Destroy(this.gameObject);
                break;
        }

       
    }
    private IEnumerator IncreasePlayerSpeedTemporarily(PlayerCharacter pc)
    {
        //store the player's original speed
        float originalSpeed = pc.moveSpeed;
        //increase this player's speed...
        pc.moveSpeed *= 2f;
        //...wait for 10 seconds
        yield return new WaitForSeconds(10f);
        //change it back to normal
        pc.moveSpeed = originalSpeed;

        //Destroy this object
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the colliding object is a player...
        if(other.CompareTag("Player"))
        {
            //if we haven't already picked up this item...
            if(!hasPickedUpItem)
            {
                //...if this can be picked up by the blue player...
                if (other.gameObject.GetComponent<PlayerCharacter>().isBluePlayer && canBePickedUpByBluePlayer)
                {
                    //...give the blue player the pickup
                    InitiateAbility(true);
                }
                //if this is the red player and can be picked up by the red player...
                if (!other.gameObject.GetComponent<PlayerCharacter>().isBluePlayer && !canBePickedUpByBluePlayer)
                {
                    //....give it to the red player
                    InitiateAbility(false);
                }
            }
        }
    }
}
