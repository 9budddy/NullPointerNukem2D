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
    [SerializeField] private float checkUpdate = 5.0f;
    [SerializeField] private Canvas doItLaterCanvas;
    [SerializeField] private TextMeshProUGUI doItLaterText;
    [SerializeField] private GameObject backgroundObj;
    [SerializeField] private GameObject iconObj;

    private SpriteRenderer backgroundSpr;
    private SpriteRenderer iconSpr;
    private bool spawnedText = false;
    void Start()
    {
        lastUpdate = 0.0f;

        rb = GetComponent<Rigidbody2D>();
        backgroundSpr = backgroundObj.GetComponent<SpriteRenderer>();
        iconSpr = iconObj.GetComponent<SpriteRenderer>();

        playerState.stopMovement = false;
        playerState.alive = true;
        doItLaterText.enabled = false;
        backgroundSpr.enabled = false;
        iconSpr.enabled = false;
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
            textBubble();
        }
        playerState.position = transform.position;

    }

    public void textBubble()
    {
        lastUpdate += Time.deltaTime;

        if (lastUpdate > checkUpdate && spawnedText)
        {
            lastUpdate = 0.0f;
            spawnedText = false;
            playerState.stopMovement = false;
            doItLaterText.enabled = false;
            backgroundSpr.enabled = false;
            iconSpr.enabled = false;
        }
        else if (lastUpdate < checkUpdate && !spawnedText)
        {
            if (transform.localScale.x == -1 )
            {
                doItLaterCanvas.transform.localScale = new Vector3(doItLaterCanvas.transform.localScale.x * -1, doItLaterCanvas.transform.localScale.y, doItLaterCanvas.transform.localScale.z);
            } 
            else
            {
                if (doItLaterCanvas.transform.localScale.x < 0)
                {
                    doItLaterCanvas.transform.localScale = new Vector3(doItLaterCanvas.transform.localScale.x * -1, doItLaterCanvas.transform.localScale.y, doItLaterCanvas.transform.localScale.z);
                }
            }

            spawnedText = true;
            doItLaterText.enabled = true;
            backgroundSpr.enabled = true;
            iconSpr.enabled = true;
        }
        lastUpdate += Time.deltaTime;
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
