using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private GameLogic gameLogic;


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
        if (collision.gameObject.tag == "CookBook" ||
            collision.gameObject.tag == "Brownie" ||
            collision.gameObject.tag == "Pendant")
        {
            gameLogic.ItemContact(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "GermanProfessor")
        {
            playerState.gotPowerUp = true;
            gameLogic.HeroContact(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
            
        else if (collision.gameObject.tag == "EnglishEducator")
        {
            playerState.gotPowerUp = true;
            gameLogic.HeroContact(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "AmericanAmplifier")
        {
            playerState.gotPowerUp = true;
            gameLogic.HeroContact(collision.gameObject.tag);
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
