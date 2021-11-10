# Cooking-Master

This is my submission for Tentworks Interactive's interview process. It's a salad chef simulation done in Unity 2019.4.30f1. 

---CONTROLS---

This is a two-player game. Controls are as follows:
Blue player:
    Movement: WASD
    Interact: F
Red player:
    Movement: Arrow keys
    Interact: K

---HOW TO PLAY---

The goal is to get as many points as possible. This is done by delivering the right salad combinations to the customer that requested it. Customers can order either a combination of two ingredients or three ingredients.  
The players will:
1. Pick up a vegetable by interacting with it. That vegetable will go into their inventory (blue inventory is on the left, while red inventory is on the right)
2. Proceed to one of the chopping boards to "chop" a vegetable. This will take two seconds and the player cannot move during those two seconds.
3. Once a vegetable is chopped, the player can, after moving away from the chopping board and moving back to it, do the following depending the number of vegetables they are holding:
    - 0: Pick up the chopped item and add it to their inventory
    - 1 or 2: Place the first item in their inventory onto the chopping board. After chopping, this will create a new combination.
4. The player can then bring the chopped salad to a customer. Interact with it and the customer will behave based on what the player gives them:
    - Correct combination: Customer is satisfied and gives the player points. If the player delivers the right combination within 70% of the customer's waiting time, the customer will drop one of the following pickups:
        - Speed: Increases that player's movement speed for ten seconds
        - Time: adds time to that player's timer
        - Score: add points to that player
    - Incorrect combination: Customer will become angry and become impatient, causing that customer's time to go down faster. If the angry customer leaves disatisfied, that player will lose double the amount of points.
5. Continue this cycle until the timer runs out

IMPORTANT NOTES

- The player must mix the ingredients in the order shown by the customer they are serving. 
- A trash can is available for players to throw items away. If they throw away a combination, they'll lose points
- Customers' timers are indicated by their color. The redder they become, the less time you have left to serve them.
- Plates (located next to the chopping boards) can hold one item. They can then be picked up if needed.
- When moving into a pickup item, it can only be used by the player that correctly served the customer within the right amount of time.