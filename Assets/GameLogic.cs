using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerState playerState;

    private bool swarm = false;
    private float lastUpdate;
    private float checkUpdate = 1.0f;


    private float lastTextUpdate;
    private float checkTextUpdate = 4f;

    void Start()
    {
        lastUpdate = 1.5f;
        lastTextUpdate = 4.5f;
        gameState.knowledgePoints = 20;
        gameState.maxKnowledgePoints = 20;
        gameState.browiePoints = 0;
        gameState.minimumKnowledgeThreshold = 5;
    }

    // Update is called once per frame
    void Update()
    {
        lastTextUpdate += Time.deltaTime;
        lastUpdate += Time.deltaTime;

        if (gameState.maxKnowledgePoints < gameState.knowledgePoints)
        {
            gameState.maxKnowledgePoints = gameState.knowledgePoints;
            gameState.minimumKnowledgeThreshold = gameState.maxKnowledgePoints / 4;
        }

        if (swarm == true && lastUpdate > checkUpdate)
        {
            lastUpdate = 0.0f;
            gameState.knowledgePoints -= (gameState.knowledgePoints / 10);
        }

        /*if (gameState.knowledgePoints < gameState.maxKnowledgePoints / 4)
        {
            Time.timeScale = 0.0f;
        }*/
    }

    public void HeroContact(string tag) 
    { 
        if (tag == "GermanProfessor")
        {

        }
        else if (tag == "EnglishEducator")
        {

        }
        else if (tag == "AmericanAmplifier")
        {

        }
    }


    public void EnemyContact(string tag)
    {
        if (tag == "Arrow")
        {
            if (gameState.knowledgePoints/2 > 10)
            {
                gameState.knowledgePoints -= gameState.knowledgePoints/2;
            } 
            else
            {
                gameState.knowledgePoints -= 10;
            }
            
        }
        else if (tag == "Swarm")
        {
            swarm = true;
        }
        else if (tag == "Pirate")
        {
            if (lastTextUpdate > checkTextUpdate)
            {
                lastTextUpdate = 0.0f;
                playerState.stopMovement = true;
            }
            
        }
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
