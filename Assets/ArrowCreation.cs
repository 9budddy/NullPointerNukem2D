using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreation : MonoBehaviour
{
    public GameObject prefab;
    
    IEnumerator CreateArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Vector2 pos = new Vector2(-5.5f, -1.5f);
        Instantiate(prefab, pos, Quaternion.identity);

    }
    void Start()
    {
        StartCoroutine(CreateArrow(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
