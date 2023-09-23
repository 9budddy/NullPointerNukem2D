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

    private void Start()
    {
        lastUpdate = 3.0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightBox")
        {
            playerState.rightColliding = false;
        }
        else if (collision.gameObject.tag == "LeftBox")
        {
            playerState.leftColliding = false;
        }
        else if (collision.gameObject.tag == "TopBox")
        {
            playerState.topColliding = false;
        }
        else if (collision.gameObject.tag == "BottomBox")
        {
            playerState.bottomColliding = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow" ||
            collision.gameObject.tag == "Swarm" ||
            collision.gameObject.tag == "Pirate")
        {
            lastUpdate += Time.deltaTime;
            if (lastUpdate > 2.0)
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
            lastUpdate += Time.deltaTime;
            if (lastUpdate > 2.0)
            {
                gameLogic.EnemyContact(collision.gameObject.tag);
                lastUpdate = 0.0f;
            }
            
        }


        if (collision.gameObject.tag == "RightBox")
        {
            playerState.rightColliding = true;
        }
        else if (collision.gameObject.tag == "LeftBox")
        {
            playerState.leftColliding = true;
        }
        else if (collision.gameObject.tag == "TopBox")
        {
            playerState.topColliding = true;
        }
        else if (collision.gameObject.tag == "BottomBox")
        {
            playerState.bottomColliding = true;
        }
    }
}
