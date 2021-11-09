using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //getter for singleton
    private static GameManager instance;
    //Singleton for this class
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    [Header("Vegetable Materials")]
    public VegetableMaterialsSO vegetableMaterialsSo;
    [Header("Spawn points")]
    //array of spawn points for customers
    public GameObject[] customerSpawnPoints;
    //array of spawn points for vegetables
    public GameObject[] vegetableSpawnPoints;
    //blue player spawn point
    public GameObject bluePlayerSpawnPoint;
    //red player spawn point
    public GameObject redPlayerSpawnPoint;
    //spawn point for spinach
    public GameObject spinachSpawnPoint;
    //spawn point for celery
    public GameObject celerySpawnPoint;
    //spawn point for lettuce
    public GameObject lettuceSpawnPoint;
    //spawn point for carrot
    public GameObject carrotSpawnPoint;
    //spawn point for tomato
    public GameObject tomatoSpawnPoint;
    //spawn point for onion
    public GameObject onionSpawnPoint;
    //spawn points for pick up items
    public GameObject[] pickupSpawnPoints;

    [Header("Player References")]
    //reference for blue player
    public PlayerCharacter bluePlayerRef;
    //reference for red player
    public PlayerCharacter redPlayerRef;

    [Header("Player Stats")]
    //blue player time
    public float bluePlayerTime;
    //blue player score
    public int bluePlayerScore;
    //red player time
    public float redPlayerTime;
    //red player score
    public int redPlayerScore;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers();
        InitSpawnVegetables();
        SpawnCustomer();

        UIManager.Instance.UpdatePlayerScore(bluePlayerScore, true);
        UIManager.Instance.UpdatePlayerScore(redPlayerScore, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitSpawnVegetables()
    {
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Spinach);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Carrot);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Celery);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Lettuce);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Onion);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Tomato);

    }

    public void RespawnVegetable(Vegetable.VegetableType typeToSpawn)
    {
        StartCoroutine(RespawnVegetableCoroutine(typeToSpawn));
    }
    private IEnumerator RespawnVegetableCoroutine(Vegetable.VegetableType type)
    {
        yield return new WaitForSeconds(2f);

        SpawnVegetableAtSpawn(type);
    }
   
    #region SPAWN_VEGETABLES
    public void SpawnVegetableAtSpawn(Vegetable.VegetableType vType)
    {
        switch(vType)
        {
            case Vegetable.VegetableType.Spinach:
                SpawnSpinach();
                break;
            case Vegetable.VegetableType.Celery:
                SpawnCelery();
                break;
            case Vegetable.VegetableType.Lettuce:
                SpawnLettuce();
                break;
            case Vegetable.VegetableType.Tomato:
                SpawnTomato();
                break;
            case Vegetable.VegetableType.Onion:
                SpawnOnion();
                break;
            case Vegetable.VegetableType.Carrot:
                SpawnCarrot();
                break;
        }
    }
    private void SpawnSpinach()
    {
        //instantiate a spinach prefab from the Resources folder at the spinach spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Spinach"), spinachSpawnPoint.transform.position, spinachSpawnPoint.transform.rotation);
    }
    private void SpawnCelery()
    {
        //instantiate a celery prefab from the Resources folder at the celery spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Celery"), celerySpawnPoint.transform.position, celerySpawnPoint.transform.rotation);
    }
    private void SpawnLettuce()
    {
        //instantiate a lettuce prefab from the Resources folder at the lettuce spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Lettuce"), lettuceSpawnPoint.transform.position, lettuceSpawnPoint.transform.rotation);
    }
    private void SpawnCarrot()
    {
        //instantiate a carrot prefab from the Resources folder at the carrot spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Carrot"), carrotSpawnPoint.transform.position, carrotSpawnPoint.transform.rotation);
    }
    private void SpawnTomato()
    {
        //instantiate a tomato prefab from the Resources folder at the tomato spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Tomato"), tomatoSpawnPoint.transform.position, tomatoSpawnPoint.transform.rotation);
    }
    private void SpawnOnion()
    {
        //instantiate an onion prefab from the Resources folder at the onion spawn point
        Instantiate((GameObject)Resources.Load("Vegetables/Onion"), onionSpawnPoint.transform.position, onionSpawnPoint.transform.rotation);
    }
    #endregion

    #region PLAYERS
    public void UpdatePlayerScore(int amount, bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            //...add the amount to the blue player's score
            bluePlayerScore += amount;
            //if our score is less than zero...
            if(bluePlayerScore < 0)
            {
                //...set the blue score to zero
                bluePlayerScore = 0;
            }
            //update the UI for the blue player's score
            UIManager.Instance.UpdatePlayerScore(bluePlayerScore, true);
        }
        //otherwise...
        else
        {
            //...add it to the red player's score
            redPlayerScore += amount;
            //if it goes below zero, set it to zero
            if(redPlayerScore < 0)
            {
                redPlayerScore = 0;
            }
            //update the UI for the red player's score
            UIManager.Instance.UpdatePlayerScore(redPlayerScore, false);
        }

    }
    public void SpawnPlayers()
    {
        //local variable that will instantiate the blue player from Resources
        GameObject spawnBlue = Instantiate((GameObject)Resources.Load("BluePlayer"), bluePlayerSpawnPoint.transform.position, bluePlayerSpawnPoint.transform.rotation);
        //assign the blue player reference to above local variable
        bluePlayerRef = spawnBlue.GetComponent<PlayerCharacter>();

        //local variable that will instantiate the red player from Resources
        GameObject spawnRed = Instantiate((GameObject)Resources.Load("RedPlayer"), redPlayerSpawnPoint.transform.position, redPlayerSpawnPoint.transform.rotation);
        //assign the red player reference to the above local variable
        redPlayerRef = spawnRed.GetComponent<PlayerCharacter>();
    }
    #endregion

    #region CUSTOMERS

    public void SpawnCustomer()
    {
        //get all the available customer spawn points
        GameObject[] availableSpawnPoints = AvailableCustomerSpawnPoints();
        //for each of the spawn points
        foreach(GameObject s in availableSpawnPoints)
        {
            //spawn a customer at s position and rotation
            GameObject customer = Instantiate((GameObject)Resources.Load("Customer"), s.transform.position, s.transform.rotation);
            //set the customer's parent to the spawn point
            customer.transform.SetParent(s.transform, true);
        }
    }

    public void DetermineCustomerBehaviourAfterInteraction(Customer.CustomerBehaviour behaviour, GameObject go)
    {
        //switch statement
        switch(behaviour)
        {
            //satisfied
            case Customer.CustomerBehaviour.Satisfied:
                StartCoroutine(OnCustomerSatisfied(go));
                break;
            //angry
            case Customer.CustomerBehaviour.Angry:
                break;
            //leaving
            case Customer.CustomerBehaviour.Leave:
                break;
        }
    }

    public void DestroyCustomer(GameObject go)
    {
        StartCoroutine(DestroyCustomer_Coroutine(go));
    }
    private IEnumerator DestroyCustomer_Coroutine(GameObject go)
    {
        Destroy(go);

        yield return new WaitForSeconds(4f);

        SpawnCustomer();
    }

    private IEnumerator OnCustomerSatisfied(GameObject go)
    {
        //get the boolean for whether this customer interacted with blue or red player
        bool blueOrRed = go.GetComponent<Customer>().interactedWithBluePlayer;
        //update the score of the player who satisfied the customer (go)
        UpdatePlayerScore(+10, blueOrRed);

        //TODO: Set up spawning pick ups, taking into account the blueOrRed value

        //Destory the customer
        Destroy(go);

        //yield return wait for four seconds
        yield return new WaitForSeconds(4f);

        //spawn another customer
        SpawnCustomer();
    }

    private GameObject[] AvailableCustomerSpawnPoints()
    {
        //set up a new list of GameObjects
        List<GameObject> spawnPointsTemp = new List<GameObject>();
        //for each of the customer spawn points
        foreach (GameObject spawn in customerSpawnPoints)
        {
            //if spawn's child count is zero...
            if (spawn.transform.childCount == 0)
            {
                //...add spawn to the list
                spawnPointsTemp.Add(spawn);
            }
        }
        //return the list as an array
        return spawnPointsTemp.ToArray();
    }
    #endregion
}
