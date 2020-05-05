using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stone : MonoBehaviour
{
    public Route currentRoute; //the route that player follows

    int routePosition; //Location in the list

    public int steps; //Number of steps the player moves

    bool isMoving; //Check if player is still moving

    public GameObject currentTile; //The tile where the player is atm
    
    //Press Space to roll
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = UnityEngine.Random.Range(2, 13); //steps is used to move the token

            StartCoroutine(Move());

        }
    }
    //This is what actaully moves the player to the next tile
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            routePosition++; 
            routePosition %= currentRoute.childNodeList.Count; //This makes the player pass the start tile and continue w/o problems

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
          
            while (MoveToNextNode(nextPos)) { yield return null; }
            
            yield return new WaitForSeconds(0.1f);
            steps--;
            

        }

        isMoving = false;

        if(!isMoving) // When the token stops do CheckTile
        {
            UnityEngine.Debug.Log("Found tile: " + currentRoute.childNodeList[routePosition].transform.name);
            UnityEngine.Debug.Log("Found rent: " + currentRoute.childNodeList[routePosition].GetComponent<Tile>().rent);
            CheckTile();
        }
    }
    //Same as top
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 4f * Time.deltaTime));

    }
    //Will continue this method to check what type of tile the player is on or will do it in a different script file
   void CheckTile()
    {
        if (currentRoute.childNodeList[routePosition].GetComponent<Tile>().type == "Property")
        {

        }
        else if (currentRoute.childNodeList[routePosition].GetComponent<Tile>().type == "Pay")
        {

        }
        else if (currentRoute.childNodeList[routePosition].GetComponent<Tile>().type == "Special")
        {

        }
    }

}
