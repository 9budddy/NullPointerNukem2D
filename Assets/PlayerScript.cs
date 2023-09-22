using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float movePower = 10f;

    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;
    Vector3 movement;
    private bool alive = true;
    private bool isTopColliding = false;
    private bool isBottomColliding = false;
    private bool isRightColliding = false;
    private bool isLeftColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Horizontal();
            Vertical();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightBox")
        {
            isRightColliding = false;
        }
        else if (collision.gameObject.tag == "LeftBox")
        {
            isLeftColliding = false;
        }
        else if (collision.gameObject.tag == "TopBox")
        {
            isTopColliding = false;
        }
        else if (collision.gameObject.tag == "BottomBox")
        {
            isBottomColliding = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightBox")
        {
            isRightColliding = true;
        }
        else if (collision.gameObject.tag == "LeftBox")
        {
            isLeftColliding = true;
        }
        else if (collision.gameObject.tag == "TopBox")
        {
            isTopColliding = true;
        }
        else if (collision.gameObject.tag == "BottomBox")
        {
            isBottomColliding = true;
        }
    }

    void Horizontal()
    {
        anim.SetBool("isRun", false);

        if (Input.GetAxisRaw("Horizontal") < 0 && !isLeftColliding)
        {
            direction = -1;
            movement += Vector3.left;

            transform.localScale = new Vector3(direction, 1, 1);

            anim.SetBool("isRun", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && !isRightColliding)
        {
            direction = 1;
            movement += Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);

            anim.SetBool("isRun", true);
        } 
        else
        {
            if (movement.x != 0)
            {
                movement.x = 0;
                anim.SetBool("isRun", false);
            }
        }

        transform.position += movement * movePower * Time.deltaTime;
    }

    void Vertical ()
    {
        movement = Vector3.zero;
        if (Input.GetAxisRaw("Vertical") > 0 && !isTopColliding)
        {
            movement += Vector3.up;
            anim.SetBool("isRun", true);

        }
        else if (Input.GetAxisRaw("Vertical") < 0 && !isBottomColliding)
        {
            movement += Vector3.down;
            anim.SetBool("isRun", true);
        }
        else
        {
            if (movement.y != 0)
            {
                anim.SetBool("isRun", false);
            }
        }
    }
}
