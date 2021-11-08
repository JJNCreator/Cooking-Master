using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //reference for waiting time
    public float defaultWaitingTime = 25f;
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
        //get a random combination
        requestedCombination = cCombinations.GetRandomCombination();
        SetIndicatorTextureBasedOnRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
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
