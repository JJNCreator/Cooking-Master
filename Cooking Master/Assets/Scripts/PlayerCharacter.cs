﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour
{
    //determines which player this is
    public bool isBluePlayer;
    //determines how fast the player will move
    public float moveSpeed = 4f;
    //can the player move?
    public bool canMove = true;

    //reference for input asset
    public PlayerActions playerActions;

    //references for current possible interaction
    public string currentPossibleInteraction;
   
    //reference for movement vector
    private Vector2 movementVector;

    //horizontal movement
    private float horizontal;
    //vertical movement
    private float vertical;

    //reference for rigidbody
    private Rigidbody rBody;

    //reference for transform
    private Transform transformCache;

    //Called before Start
    private void Awake()
    {
        //Store the Rigidbody component
        rBody = GetComponent<Rigidbody>();

        //Store the Transform component
        transformCache = transform;

        //Initiate player actions
        InitiateInputActions();
    }

    private void OnEnable()
    {
        //Enable player actions
        playerActions.Enable();
    }

    private void OnDisable()
    {
        //Disable player actions
        playerActions.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Move the character
        MoveCharacter(movementVector);
    }
    private void MoveCharacter(Vector3 input)
    {
        //Set the rigidbody's velocity to that of the above vector
        rBody.velocity = new Vector3(horizontal * moveSpeed, rBody.velocity.y, vertical * moveSpeed);
    }
    private void InitiateInputActions()
    {
        //Initiate
        playerActions = new PlayerActions();
        //If we're the blue player...
        if(isBluePlayer)
        {
            playerActions.BluePlayer.Movement.performed += ctx =>
            {
                //...if we can move...
                if (canMove)
                {
                    //...then move the character
                    horizontal = ctx.ReadValue<Vector2>().x;
                    vertical = ctx.ReadValue<Vector2>().y;
                }
            };
            playerActions.BluePlayer.Interact.performed += ctx =>
            {
                Debug.Log("PlayerCharacter:InitiateInputActions() - Blue player interacted");
                Interact(currentPossibleInteraction);

            };
        }
        //if we're the red player...
        else
        {
            playerActions.RedPlayer.Movement.performed += ctx =>
            {
                //if we can move...
                if(canMove)
                {
                    //...then move the character
                    horizontal = ctx.ReadValue<Vector2>().x;
                    vertical = ctx.ReadValue<Vector2>().y;
                }
            };
            playerActions.RedPlayer.Interact.performed += ctx =>
            {
                Debug.Log("PlayerCharacter:InitiateInputActions() - Red player interacted");
                Interact(currentPossibleInteraction);
            };
        }
    }
    private void Interact(string tagForInteractingObject)
    {
        //switch case
        switch(tagForInteractingObject)
        {
            case "Vegetable":
                //TODO: Set up function for collecting vegetables
                break;
            case "Customer":
                //TODO: Set up function for interacting with customers
                break;
            case "ChoppingBoard":
                //TODO: Set up function for interacting with chopping board
                break;
            case "TrashCan":
                //TODO: Set up function for putting vegetables in trash can
                break;
        }
        currentPossibleInteraction = string.Empty;

    }
    private void OnTriggerEnter(Collider other)
    {
        //enable vegetable interaction if collider tag is Vegetable
        if(other.CompareTag("Vegetable"))
        {
            currentPossibleInteraction = "Vegetable";
        }
        //enable customer interaction if collider tag is Customer
        if(other.CompareTag("Customer"))
        {
            currentPossibleInteraction = "Customer";
        }
        //enable chopping board interaction if collider tag is ChoppingBoard
        if(other.CompareTag("ChoppingBoard"))
        {
            currentPossibleInteraction = "ChoppingBoard";
        }
        //enable trash can interaction if collider tag is TrashCan
        if(other.CompareTag("TrashCan"))
        {
            currentPossibleInteraction = "TrashCan";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentPossibleInteraction = string.Empty;
    }
}
