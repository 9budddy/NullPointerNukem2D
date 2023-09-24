using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreation : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField] private GameState gameState;

    IEnumerator CreateArrow(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector2 pos = new Vector2(-5.5f, -1.5f);
            GameObject enemy = Instantiate(arrow, pos, Quaternion.identity);
            gameState.enemyObjects.Add(enemy);
        }

    }
    void Start()
    {
        //StartCoroutine(CreateArrow(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
