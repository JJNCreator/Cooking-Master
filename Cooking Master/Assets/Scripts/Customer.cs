using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string requestedCombination;
    private CustomerCombinations cCombinations;

    //Called before Start
    private void Awake()
    {
        cCombinations = new CustomerCombinations();
    }
    // Start is called before the first frame update
    void Start()
    {
        requestedCombination = cCombinations.GetRandomCombination();
    }

    // Update is called once per frame
    void Update()
    {
        
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
