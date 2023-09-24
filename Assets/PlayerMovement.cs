using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            
            Horizontal();
            Vertical();
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
