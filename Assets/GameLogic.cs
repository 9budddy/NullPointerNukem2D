using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerState playerState;
    [SerializeField] private TextMeshProUGUI immuneText;
    [SerializeField] private TextMeshProUGUI knowledgeDoubledText;
    [SerializeField] private TextMeshProUGUI enemiesDestroyedText;

    private bool triggerHero = false;
    private bool swarm = false;
    private bool knowledgeDouble = false;
    private bool enemiesDestroyed = false;

    private float lastUpdate;
    [SerializeField] private float checkUpdate = 1.0f;

    private float lastPirateTextUpdate;
    [SerializeField] private float checkPirateTextUpdate = 4f;
    [SerializeField] private float timedImmuneTextUpdate = 6f;
    [SerializeField] private float timedKnowledgeTextUpdate = 3.0f;
    [SerializeField] private float timedEnemiesDestroyTextUpdate = 3.0f;

    void Start()
    { 

        //TIME UPDATES
        lastUpdate = checkUpdate + 0.5f;
        lastPirateTextUpdate = checkPirateTextUpdate + 0.5f;

        //GAMESTATE ITEMS
        gameState.knowledgePoints = 20;
        gameState.maxKnowledgePoints = 20;
        gameState.browiePoints = 5;
        gameState.minimumKnowledgeThreshold = 5;

        //TEXT STATES
        immuneText.enabled = false;
        knowledgeDoubledText.enabled = false;
        enemiesDestroyedText.enabled = false;

        //PLAYER STATES
        playerState.immune = false;
        playerState.gotPowerUp = false;
    }

    void Update()
    {
        //TIME UPDATES
        lastUpdate += Time.deltaTime;
        lastPirateTextUpdate += Time.deltaTime;


        //UPDATE POINTS
        checkNewMaxandMinPoints();

        //KNOWLEDGE DOUBLED TEXT
        doubleKnowledge();

        //ENEMIES DESTROYED TEXT
        enemyDestroy();

        //PLAYER GETTING SWARMED
        swarmDamage();

        //PLAYER IMMUNE
        if (playerState.immune)
        {
            playerImmune();
        } 
         
        //GAME END
        /*if (gameState.knowledgePoints < gameState.maxKnowledgePoints / 4)
        {
            Time.timeScale = 0.0f;
        }*/
    }

    private void enemyDestroy()
    {
        if (enemiesDestroyed)
        {

            if (!enemiesDestroyedText.enabled)
            {
                enemiesDestroyedText.enabled = true;
            }
            if (timedKnowledgeTextUpdate <= 0)
            {

                enemiesDestroyedText.enabled = false;
                enemiesDestroyed = false;
                timedKnowledgeTextUpdate = 3.0f;

            }
            timedKnowledgeTextUpdate -= Time.deltaTime;
        }
    }

    private void doubleKnowledge()
    {
        if (knowledgeDouble)
        {
            
            if (!knowledgeDoubledText.enabled)
            {
                knowledgeDoubledText.enabled = true;
            }
            if (timedEnemiesDestroyTextUpdate <= 0)
            {

                knowledgeDoubledText.enabled = false;
                knowledgeDouble = false;
                timedEnemiesDestroyTextUpdate = 3.0f;

            }
            timedEnemiesDestroyTextUpdate -= Time.deltaTime;
        }
    }

    private void swarmDamage()
    {
        if (swarm == true && lastUpdate <= checkUpdate)
        {
            if (playerState.gotPowerUp)
            {
                lastUpdate = checkUpdate + 0.5f;
                playerState.gotPowerUp = false;
                swarm = false;
            }
        }
        else if (swarm == true && lastUpdate > checkUpdate)
        {
            lastUpdate = 0.0f;
            gameState.knowledgePoints -= (gameState.knowledgePoints / 10);
        }
    }

    private void checkNewMaxandMinPoints()
    {
        if (gameState.maxKnowledgePoints < gameState.knowledgePoints)
        {
            gameState.maxKnowledgePoints = gameState.knowledgePoints;
            gameState.minimumKnowledgeThreshold = gameState.maxKnowledgePoints / 4;
        }
    }

    private void playerImmune()
    {
        TimeSpan ts = TimeSpan.FromSeconds(timedImmuneTextUpdate);
        immuneText.text = "Immune " + ts.ToString("m':'ss");
        if (!immuneText.enabled)
        {
            immuneText.enabled = true;
        }
        if (timedImmuneTextUpdate <= 0)
        {

            immuneText.enabled = false;
            playerState.immune = false;
            timedImmuneTextUpdate = 6.0f;

        }
        timedImmuneTextUpdate -= Time.deltaTime;
    }

    public void HeroContact(string tag) 
    {
        triggerHero = (gameState.browiePoints >= 10) ? true : false;
        gameState.browiePoints = 0;
        if (triggerHero)
        {
            if (tag == "GermanProfessor")
            {
                //Destroy all enemies on screen
                foreach (GameObject enemy in gameState.enemyObjects) 
                {
                    Destroy(enemy);
                }
                enemiesDestroyed = true;
                
            }
            else if (tag == "EnglishEducator")
            {
                //Make player immune
                playerState.immune = true;

            }
            else if (tag == "AmericanAmplifier")
            {
                //Double player's current knowledge
                gameState.knowledgePoints *= 2;
                knowledgeDouble = true;
            }
        }
    }


    public void EnemyContact(string tag)
    {
        if (!playerState.immune)
        {
            if (tag == "Arrow")
            {
                if (gameState.knowledgePoints / 2 > 10)
                {
                    gameState.knowledgePoints -= gameState.knowledgePoints / 2;
                }
                else
                {
                    gameState.knowledgePoints -= 10;
                }

            }
            else if (tag == "Swarm")
            {
                //Turn Swarm on for Damage Over Time
                swarm = true;
            }
            else if (tag == "Pirate")
            {
                //ToggleStopped Movement to spawn Text
                
                //EXTRA: Make it so text spawns where player is. 
                if (lastPirateTextUpdate > checkPirateTextUpdate)
                {
                    lastPirateTextUpdate = 0.0f;
                    playerState.stopMovement = true;
                }

            }
        }
    }

    public void ItemContact(string tag)
    {
        if (tag == "CookBook")
        {
            //Add 1 knowledge points to total
            gameState.knowledgePoints += 1;

        } 
        else if (tag == "Pendant")
        {
            //Add 25 knowledge points to total
            gameState.knowledgePoints += 25;

        } 
        else if (tag == "Brownie")
        {
            //Add 1 brownie points to total
            gameState.browiePoints += 1;

        }
    }
}
