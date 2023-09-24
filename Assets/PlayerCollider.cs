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

    private float lastUpdate;
    private float checkUpdate = 1.5f;

    [SerializeField] private BoundaryScript bScript;


    private void Start()
    {
        lastUpdate = 3.0f;
    }

    private void Update()
    {
        bScript.tryCamera(gameObject);
        lastUpdate += Time.deltaTime;
        
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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow" ||
            collision.gameObject.tag == "Swarm" ||
            collision.gameObject.tag == "Pirate")
        {
            if (lastUpdate > checkUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastUpdate = 0.0f;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow" ||
            collision.gameObject.tag == "Swarm" ||
            collision.gameObject.tag == "Pirate")
        {
            if (lastUpdate > checkUpdate)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastUpdate = 0.0f;
            }
        }
    }
}
