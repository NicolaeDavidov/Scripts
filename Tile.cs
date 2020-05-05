using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject obj; //Object To Render The Tile

    public string type; //property, transport....)

    public int rent; //Self explanatory

    public int morgage; //Self explanatory

    public int buyPrice; //Self explanatory

    public bool isOwned; //Self explanatory

    public bool canBeBought; //Self explanatory

    // Find it's object in the game
    void Start()
    {
        obj = GameObject.Find(name);
        
    }

}
