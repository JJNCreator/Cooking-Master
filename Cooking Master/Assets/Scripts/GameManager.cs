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

    [Header("Player References")]
    //reference for blue player
    public PlayerCharacter bluePlayerRef;
    //reference for red player
    public PlayerCharacter redPlayerRef;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
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
