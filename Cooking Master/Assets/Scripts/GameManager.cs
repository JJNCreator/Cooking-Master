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
        TestSpawnVegetables();
        TestCustomerSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TestSpawnVegetables()
    {
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Spinach);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Carrot);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Celery);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Lettuce);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Onion);
        SpawnVegetableAtSpawn(Vegetable.VegetableType.Tomato);

    }
    private void TestCustomerSpawn()
    {
        for(int i = 0; i < customerSpawnPoints.Length; i++)
        {
            GameObject spawnPoint = customerSpawnPoints[i];
            GameObject go = Instantiate((GameObject)Resources.Load("Customer"), spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
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
}
