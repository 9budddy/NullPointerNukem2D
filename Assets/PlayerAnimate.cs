using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk()
    {
        anim.SetBool("isRun", false);
    }

    public void Run()
    {
        anim.SetBool("isRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
