using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float movePower = 10f;

    private Rigidbody2D rb;

    [SerializeField]
    private PlayerState playerState;

    [SerializeField]
    private PlayerAnimate playerAnimate;

    private int direction = 1;
    Vector3 movement;

    private float lastUpdate;
    [SerializeField]private float checkUpdate = 5.0f;
    private bool spawnedText = false;
    [SerializeField] private TextMeshProUGUI doItLaterText;
    void Start()
    {
        lastUpdate = 0.0f;
        playerState.stopMovement = false;
        rb = GetComponent<Rigidbody2D>();
        playerState.alive = true;
        doItLaterText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerState.alive && !playerState.stopMovement)
        {
            Horizontal();
            Vertical();
        }
        else if (playerState.alive && playerState.stopMovement)
        {
            lastUpdate += Time.deltaTime;
            
            if (lastUpdate > checkUpdate && spawnedText)
            {
                lastUpdate = 0.0f;
                spawnedText = false;
                playerState.stopMovement = false;
                doItLaterText.enabled = false;
            } 
            else if (lastUpdate < checkUpdate && !spawnedText)
            {
                spawnedText = true;
                doItLaterText.enabled = true;
                doItLaterText.SetText("I'll do it later.");
                doItLaterText.alignment = TextAlignmentOptions.Center;
                

            }
            lastUpdate += Time.deltaTime;
        }
        playerState.position = transform.position;

    }


    void Horizontal()
    {

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1;
            movement += Vector3.left;

            transform.localScale = new Vector3(direction, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = 1;
            movement += Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);
        } 
        else
        {
            movement.x = 0f;
        }


        if (movement == Vector3.zero)
        {
            playerAnimate.Walk();
        } 
        else
        {
            playerAnimate.Run();
        }

        transform.position += movement * movePower * Time.deltaTime;
    }

    void Vertical ()
    {
        movement = Vector3.zero;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            movement += Vector3.up;

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            movement += Vector3.down;
        }
        else
        {
            movement.y = 0f;
        }
    }
}
