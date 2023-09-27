using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private GameState gameState;
    [SerializeField] private GameLogic gameLogic;


    private float lastArrowUpdate;
    private float checkArrowUpdate = 1.5f;

    private float lastSwarmUpdate;
    private float checkSwarmUpdate = 1.5f;

    private float lastPirateUpdate;
    private float checkPirateUpdate = 1.5f;

    [SerializeField] private BoundaryScript bScript;


    private void Start()
    {
        lastArrowUpdate = 3.0f;
        lastSwarmUpdate = 3.0f;
        lastPirateUpdate = 3.0f;
    }

    private void Update()
    {
        bScript.tryCamera(gameObject);
        lastArrowUpdate += Time.deltaTime;
        lastSwarmUpdate += Time.deltaTime;
        lastPirateUpdate += Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CookBook")
        {
            gameLogic.ItemContact(collision.gameObject.tag);
            if (gameState.itemCookbooks.Count != 0)
            {
                gameState.itemCookbooks.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Brownie")
        {
            gameLogic.ItemContact(collision.gameObject.tag);
            if (gameState.itemBrownies.Count != 0)
            {
                gameState.itemBrownies.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Pendant")
        {
            gameLogic.ItemContact(collision.gameObject.tag);
            if (gameState.itemPendants.Count != 0)
            {
                gameState.itemPendants.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "GermanProfessor")
        { 
            gameLogic.HeroContact(collision.gameObject.tag);
            if (gameState.heroGermans.Count != 0)
            {
                gameState.heroGermans.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }
            
        else if (collision.gameObject.tag == "EnglishEducator")
        {
            gameLogic.HeroContact(collision.gameObject.tag);
            if (gameState.heroEnglishs.Count != 0)
            {
                gameState.heroEnglishs.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "AmericanAmplifier")
        {
            gameLogic.HeroContact(collision.gameObject.tag);
            if (gameState.heroAmericans.Count != 0)
            {
                gameState.heroAmericans.RemoveAt(0);
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            if (lastArrowUpdate > checkArrowUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastArrowUpdate = 0.0f;
            }
        }
        else if (collision.gameObject.tag == "Swarm")
        {
            if (lastSwarmUpdate > checkSwarmUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastSwarmUpdate = 0.0f;
            }
        }
        else if (collision.gameObject.tag == "Pirate")
        {
            if (lastPirateUpdate > checkPirateUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastPirateUpdate = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            if (lastArrowUpdate > checkArrowUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastArrowUpdate = 0.0f;
            }
        }
        else if (collision.gameObject.tag == "Swarm")
        {
            if (lastSwarmUpdate > checkSwarmUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastSwarmUpdate = 0.0f;
            }
        }
        else if (collision.gameObject.tag == "Pirate")
        {
            if (lastPirateUpdate > checkPirateUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastPirateUpdate = 0.0f;
            }
        }
    }
}
