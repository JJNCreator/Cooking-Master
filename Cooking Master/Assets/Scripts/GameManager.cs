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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
