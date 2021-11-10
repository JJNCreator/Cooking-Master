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
    //reference for waiting time for three ingredients
    private float waitingTimeForThreeCombo = 60f;
    //reference for waiting time for two ingredients
    private float waitingTimeForTwoCombo = 50f;
    //reference for assigned waiting time
    public float assignedWaitingTime;
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

    //reference for this customer's Renderer
    private Renderer rendererCom;
    //reference for red Color
    private Color redColor = Color.red;
    //reference for original color
    private Color originalColor;
    //reference for t for color lerping
    private float t = 0;

    //Called before Start
    private void Awake()
    {
        //store this customer's renderer
        rendererCom = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //store this customer's original material color
        originalColor = rendererCom.material.GetColor("_BaseColor");

        //set the customer's behaviour to waiting
        currentBehaviour = CustomerBehaviour.Waiting;
        //get a random combination
        requestedCombination = RandomCombinationRequest();
        //Set the indicator plane based on the request
        SetPlanesBasedOnRequest();

        //set the current waiting time to the assigned waiting time
        currentTimeWaiting = assignedWaitingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is in progress...
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            //if our current waiting time is greater than zero...
            if (currentTimeWaiting > 0)
            {
                //...if we're angry...
                if (currentBehaviour == CustomerBehaviour.Angry)
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
                //lerp between this customer's original color and the red one based on the amount of time we have left
                rendererCom.material.SetColor("_BaseColor", Color.Lerp(originalColor, redColor, t));
                //if t is below the end limit...
                if (t < 1)
                {
                    //...add to t time.deltatime divided by our current waiting time
                    t += Time.deltaTime / currentTimeWaiting;
                }

            }
            //if our waiting time is less than or equal to zero...
            if (currentTimeWaiting <= 0)
            {
                //...and we're either waiting or angry...
                if (currentBehaviour == CustomerBehaviour.Waiting || currentBehaviour == CustomerBehaviour.Angry)
                {
                    //...call OnCustomerLeft
                    OnCustomerLeft();
                }
            }
        }
    }
    private void OnCustomerLeft()
    {
        //set up a float for doubling minus points
        int doubleModifier = 2;
        //switch statement
        switch (currentBehaviour)
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
    private float SeventyPercentOf()
    {
        //return the following equation: (70/100) * assigned waiting time
        return (70f / 100f) * assignedWaitingTime;
    }
    public void DetermineBehaviour(string itemNameFromPlayer, bool blueOrRed)
    {
        //set this customer's interactWithBluePlayer based on the provided boolean
        interactedWithBluePlayer = blueOrRed;
        //if the item name matches the requested combination...
        if (itemNameFromPlayer == requestedCombination)
        {
            //...customer is satisfied!
            currentBehaviour = CustomerBehaviour.Satisfied;
            //if we delivered before seventy percent of the waiting time...
            if (currentTimeWaiting > SeventyPercentOf())
            {
                Debug.Log("Customer:DetermineBehaviour() - delivered withing 70% of the waiting time! Here's a pickup!");
                GameManager.Instance.SpawnPickup(interactedWithBluePlayer);
            }
        }
        //otherwise...
        else
        {
            //...customer is FURIOUS
            currentBehaviour = CustomerBehaviour.Angry;
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
        switch (randomInteger)
        {
            case 0:
                returnValue = string.Format("{0},{1}", vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)]);
                assignedWaitingTime = waitingTimeForTwoCombo;
                break;
            case 1:
                returnValue = string.Format("{0},{1},{2}", vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)], vegetableNames[Random.Range(0, vegetableNames.Length)]);
                assignedWaitingTime = waitingTimeForThreeCombo;
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
        if (triple)
        {
            //...if the double parent exists...
            if (doubleComboParent != null)
            {
                //...disable it
                doubleComboParent.SetActive(false);
            }
            //if the triple parent exists...
            if (tripleComboParent != null)
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
}
