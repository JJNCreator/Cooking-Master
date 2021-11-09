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
    //reference for double combo parent object
    public GameObject doubleComboParent;
    //reference for triple combo parent object
    public GameObject tripleComboParent;
    //reference for array of double combo planes
    public Renderer[] doubleComboPlanes;
    //reference for array of triple combo planes
    public Renderer[] tripleComboPlanes;
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
        //set the current waiting time to the default waiting time
        currentTimeWaiting = defaultWaitingTime;
        //set the customer's behaviour to waiting
        currentBehaviour = CustomerBehaviour.Waiting;
        //get a random combination
        requestedCombination = RandomCombinationRequest();
        //Set the indicator plane based on the request
        SetPlanesBasedOnRequest();
    }

    // Update is called once per frame
    void Update()
    {
        //if our current waiting time is greater than zero...
        /*if(currentTimeWaiting > 0)
        {
            //...if we're angry...
            if(currentBehaviour == CustomerBehaviour.Angry)
            {
                //...subtract our current waiting time by time.deltatime * 1.5
                currentTimeWaiting -= Time.deltaTime * 1.5f;
            }
            //...if we're just waiting...
            else
            {
                //...subtract it by time.deltatime * 1
                currentTimeWaiting -= Time.deltaTime * 1f;
            }
        }
        //if our waiting time is less than or equal to zero...
        if(currentTimeWaiting <= 0)
        {
            //...and we're either waiting or angry...
            if(currentBehaviour == CustomerBehaviour.Waiting || currentBehaviour == CustomerBehaviour.Angry)
            {
                //...call OnCustomerLeft
                OnCustomerLeft();
            }
        }*/
    }
    private void OnCustomerLeft()
    {
        //set up a float for doubling minus points
        int doubleModifier = 2;
        //switch statement
        switch(currentBehaviour)
        {
            //we're angry
            case CustomerBehaviour.Angry:
                //subtract double points from the player who delivered the wrong meal
                GameManager.Instance.UpdatePlayerScore(-5 * doubleModifier, interactedWithBluePlayer);
                break;
            //we're waiting
            case CustomerBehaviour.Waiting:
                //subtract points from both players
                GameManager.Instance.UpdatePlayerScore(-5, true);
                GameManager.Instance.UpdatePlayerScore(-5, false);
                break;
        }
        GameManager.Instance.DestroyCustomer(this.gameObject);
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
    private string RandomCombinationRequest()
    {
        //set up an array of strings that will contain all the vegetable names
        string[] vegetableNames = new string[]
        {
            "Spinach",
            "Celery",
            "Lettuce",
            "Carrot",
            "Tomato",
            "Onion"
        };
        //set up a string that will be the return value
        string returnValue = string.Empty;

        //set up a random integer between 0 and 2 (inclusive)
        int randomInteger = Random.Range(0, 2);
        //switch
        switch(randomInteger)
        {
            case 0:
                returnValue = string.Format("{0},{1}", vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)]);
                break;
            case 1:
                returnValue = string.Format("{0},{1},{2}", vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)]);
                break;
        }

        //return generated string
        return returnValue;
    }
    private void SetPlanesBasedOnRequest()
    {
        //local variable for comma counter
        int commaCounter = 0;
        //for each part of the item name...
        for (int i = 0; i < requestedCombination.Length; i++)
        {
            //...if the item name contains a ','...
            if (requestedCombination.Substring(i, 1) == ",")
            {
                //...add one to the comma counter
                commaCounter++;
            }
        }

        //switch statement for comma counter
        switch (commaCounter)
        {
            //we have one comma
            case 1:
                //enable only the double sprite
                TogglePlanes(false);
                SetTexturesForMuliplePlanes(false);
                break;
            //we have two commas
            case 2:
                //enable only the triple sprite
                TogglePlanes(true);
                SetTexturesForMuliplePlanes(true);
                break;
        }
    }
    private void SetTexturesForMuliplePlanes(bool triple)
    {
        //set up an array of strings by splitting the item name using comma
        string[] splitStrings = requestedCombination.Split(',');
        //set up a list of strings
        List<string> listOfStrings = new List<string>();
        //for each of the strings in the array...
        foreach (string s in splitStrings)
        {
            //...add s to the list of strings
            listOfStrings.Add(s);
        }

        //for each of the strings in the list...
        for (int i = 0; i < listOfStrings.Count; i++)
        {
            //...set up a sprite that is retrieved from Resources, using s
            Sprite itemSprite = Resources.Load<Sprite>(string.Format("VegetableSprites/{0}", listOfStrings[i]));
            //set the sprites by i
            if (!triple)
            {
                doubleComboPlanes[i].material.SetTexture("_BaseMap", Resources.Load<Texture>(string.Format("VegetableTextures/{0}", listOfStrings[i])));
            }
            else
            {
                tripleComboPlanes[i].material.SetTexture("_BaseMap", Resources.Load<Texture>(string.Format("VegetableTextures/{0}", listOfStrings[i])));
            }
        }

    }
    private void TogglePlanes(bool triple)
    {
        //if we're requesting a triple combination...
        if(triple)
        {
            //...if the double parent exists...
            if(doubleComboParent != null)
            {
                //...disable it
                doubleComboParent.SetActive(false);
            }
            //if the triple parent exists...
            if(tripleComboParent != null)
            {
                //...enable it
                tripleComboParent.SetActive(true);
            }
        }
        //if we're requesting a double combination...
        else
        {
            //...if the double parent exists...
            if (doubleComboParent != null)
            {
                //...enable it
                doubleComboParent.SetActive(true);
            }
            //if the triple parent exists...
            if (tripleComboParent != null)
            {
                //...disable it
                tripleComboParent.SetActive(false);
            }
        }
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
