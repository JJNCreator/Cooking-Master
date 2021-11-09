using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum CustomerBehaviour
    {
        Satisfied,
        Waiting,
        Angry,
        Leave
    }
    //reference for current behaviour
    public CustomerBehaviour currentBehaviour;
    //did this customer interact with the blue player?
    public bool interactedWithBluePlayer;
    //reference for waiting time
    public float defaultWaitingTime = 25f;
    //reference for current time waiting
    public float currentTimeWaiting;
    //reference for requested combination
    public string requestedCombination;
    //reference for comnbination indicator plane
    public GameObject combinationIndicatorPlane;
    //reference for CustomerCombinations object
    private CustomerCombinations cCombinations;

    //Called before Start
    private void Awake()
    {
        cCombinations = new CustomerCombinations();
    }
    // Start is called before the first frame update
    void Start()
    {
        //set the customer's behaviour to waiting
        currentBehaviour = CustomerBehaviour.Waiting;
        //get a random combination
        requestedCombination = cCombinations.GetRandomCombination();
        //Set the indicator plane based on the request
        SetIndicatorTextureBasedOnRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DetermineBehaviour(string itemNameFromPlayer, bool blueOrRed)
    {
        //set this customer's interactWithBluePlayer based on the provided boolean
        interactedWithBluePlayer = blueOrRed;
        //if the item name matches the requested combination...
        if(itemNameFromPlayer == requestedCombination)
        {
            //...customer is satisfied!
            currentBehaviour = CustomerBehaviour.Satisfied;
        }
        //otherwise...
        else
        {
            //...customer is FURIOUS
            currentBehaviour = CustomerBehaviour.Angry;
            //TODO: Speed up the wait time here
        }

        //set the game manager's code based on this customer's behaviour
        GameManager.Instance.DetermineCustomerBehaviourAfterInteraction(currentBehaviour, this.gameObject);
    }
    private void SetIndicatorTextureBasedOnRequest()
    {
        //list of split strings from requested combination
        string[] splitStrings = requestedCombination.Split(',');
        //set up a new string
        string combinationWithoutComa = string.Empty;
        //for each of the split strings...
        foreach(string s in splitStrings)
        {
            //...add s to the new string above
            combinationWithoutComa += s;
        }

        //if the plane exists...
        if(combinationIndicatorPlane != null)
        {
            //...then set its texture to the one based on the new string. Load from Resources.
            combinationIndicatorPlane.GetComponent<Renderer>().material.SetTexture("_BaseMap", (Texture2D)Resources.Load(string.Format("VegetableCombinations/Textures/{0}", combinationWithoutComa)));
        }
    }
}
public class CustomerCombinations
{
    public string[] combinations = new string[]
    {
        "Spinach,Celery,Lettuce",
        "Spinach,Celery,Carrot",
        "Spinach,Celery,Tomato",
        "Spinach,Celery,Onion",
        "Spinach,Lettuce,Carrot",
        "Spinach,Lettuce,Tomato",
        "Spinach,Lettuce,Onion",
        "Spinach,Carrot,Tomato",
        "Spinach,Carrot,Onion",
        "Spinach,Tomato,Onion",
        "Celery,Lettuce,Carrot",
        "Celery,Lettuce,Tomato",
        "Celery,Lettuce,Onion",
        "Celery,Carrot,Tomato",
        "Celery,Carrot,Onion",
        "Celery,Tomato,Onion",
        "Lettuce,Carrot,Tomato",
        "Lettuce,Carrot,Onion",
        "Lettuce,Tomato,Onion",
        "Carrot,Tomato,Onion",
        "Spinach,Celery",
        "Spinach,Lettuce",
        "Spinach,Carrot",
        "Spinach,Tomato",
        "Spinach,Onion",
        "Celery,Lettuce",
        "Celery,Carrot",
        "Celery,Tomato",
        "Celery,Onion",
        "Lettuce,Carrot",
        "Lettuce,Tomato",
        "Lettuce,Onion",
        "Carrot,Tomato",
        "Carrot,Onion",
        "Tomato,Onion"
    };
    public string GetRandomCombination()
    {
        return combinations[Random.Range(0, combinations.Length)];
    }
}
