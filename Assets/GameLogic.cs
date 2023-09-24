using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemContact(string tag)
    {
        if (tag == "CookBook")
        {
            gameState.knowledgePoints += 1;
            return;
        } 
        else if (tag == "Pendant")
        {
            gameState.knowledgePoints += 25;
            return;
        } 
        else if (tag == "Brownie")
        {
            gameState.browiePoints += 1;
            return;
        }
    }
}
