using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class BoundaryScript : MonoBehaviour
{

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float objectExtraWidth;
    private float objectExtraHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    void Update()
    {
        
    }

    public void tryCamera(GameObject obj)
    {
        
        objectWidth = obj.transform.GetComponent<BoxCollider2D>().bounds.size.x;
        objectHeight = obj.transform.GetComponent<BoxCollider2D>().bounds.size.y;
        objectExtraWidth = (objectHeight / 16);
        objectExtraHeight = (objectHeight / 16);

        Vector3 viewPos = obj.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + (objectWidth - objectExtraWidth), screenBounds.x - (objectWidth - objectExtraWidth));
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y - (objectHeight - objectExtraHeight));
        obj.transform.position = viewPos;
    }
}
