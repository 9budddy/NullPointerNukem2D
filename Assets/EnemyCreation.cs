using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float objectExtraWidth;
    private float objectExtraHeight;


    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject arrowWidth;
    [SerializeField] private GameObject arrowHeight;
    [SerializeField] private GameObject swarm;
    [SerializeField] private GameObject pirate;
    [SerializeField] private GameObject german;
    [SerializeField] private GameObject english;
    [SerializeField] private GameObject american;
    [SerializeField] private GameObject cookbook;
    [SerializeField] private GameObject brownie;
    [SerializeField] private GameObject pendant;


    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerState playerState;

    //VERY RARE:    (9, 13) -> (6, 14)
    //RARE:         (7, 11) ->  (8, 16)
    //MEDIUM:       (5, 9) ->  (10, 18)
    //OFTEN:        (3,7) ->    (12, 20) 
    //VERY OFTEN:   (1,5) ->    (14, 22)

    //IF (3 Enemy(singleTyped) -> Delete and put another on)
    //IF (2 Hero(singleTyped) -> Delete and put another on)
    //IF (6 Item(singleTyped) -> Delete and put another on)

    [SerializeField] private float minVeryRareCreate = 5f;
    [SerializeField] private float maxVeryRareCreate = 13f;
    [SerializeField] private float minVeryRareDelete = 6f;
    [SerializeField] private float maxVeryRareDelete = 13f;

    [SerializeField] private float minRareCreate = 4f;
    [SerializeField] private float maxRareCreate = 12f;
    [SerializeField] private float minRareDelete = 7f;
    [SerializeField] private float maxRareDelete = 15f;

    [SerializeField] private float minMediumCreate = 3f;
    [SerializeField] private float maxMediumCreate = 11f;
    [SerializeField] private float minMediumDelete = 8f;
    [SerializeField] private float maxMediumDelete = 17f;

    [SerializeField] private float minOftenCreate = 2f;
    [SerializeField] private float maxOftenCreate = 10f;
    [SerializeField] private float minOftenDelete = 9f;
    [SerializeField] private float maxOftenDelete = 19f;

    [SerializeField] private float minVeryOftenCreate = 7f;
    [SerializeField] private float maxVeryOftenCreate = 11f;
    [SerializeField] private float minVeryOftenDelete = 8f;
    [SerializeField] private float maxVeryOftenDelete = 16f;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CreateArrow(minRareCreate, maxRareCreate));
    }

    private Vector3 WithinScreen(GameObject obj, GameObject obj2, string type)
    {
        if (type == "poly")
        {
            objectHeight = obj2.transform.GetComponent<BoxCollider2D>().size.y;
        }
        else if (type == "box")
        {
            objectHeight = obj.transform.GetComponent<BoxCollider2D>().size.y;
        }
        objectWidth = obj.transform.GetComponent<BoxCollider2D>().size.x;
        

        Debug.Log(objectWidth + " " + objectHeight);

        objectExtraWidth = (objectHeight / 16);
        objectExtraHeight = (objectHeight / 16);

        Vector3 viewPos = obj.transform.position;
        viewPos.x = UnityEngine.Random.Range(screenBounds.x * -1 + (objectWidth - objectExtraWidth), screenBounds.x - (objectWidth - objectExtraWidth));
        viewPos.y = UnityEngine.Random.Range(screenBounds.y * -1, screenBounds.y - (objectHeight - objectExtraHeight));


        //if (viewPos.x < transform.position.x + objectWidth * 2 && viewPos.x > transform.position.x - objectWidth * 2) ; // It is within x... respawn &&
        //if (viewPos.y < transform.position.y + objectHeight * 2 && viewPos.y > transform.position.y - objectHeight * 2) ; // It is within y... respawn ||
        //if (viewPos.x > screenBounds.x || viewPos.y > screenBounds.y || viewPos.x < -screenBounds.x || viewPos.y < -screenBounds.y) // It is out of bounds...respawn
        while ((viewPos.x < playerState.position.x + objectWidth * 2 && viewPos.x > playerState.position.x - objectWidth * 2) &&
            (viewPos.y < playerState.position.y + objectHeight * 2 && viewPos.y > playerState.position.y - objectHeight * 2) ||
            (viewPos.x > screenBounds.x || viewPos.y > screenBounds.y || viewPos.x < -screenBounds.x || viewPos.y < -screenBounds.y))
        {
            viewPos.x = UnityEngine.Random.Range(screenBounds.x * -1 + (objectWidth - objectExtraWidth), screenBounds.x - (objectWidth - objectExtraWidth));
            viewPos.y = UnityEngine.Random.Range(screenBounds.y * -1, screenBounds.y - (objectHeight - objectExtraHeight));
        }

        return viewPos;
    }

    //RARE: (8, 15) ->  (6, 11)
    IEnumerator CreateArrow(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(arrowWidth, arrowHeight, "poly");
            GameObject enemy = Instantiate(arrow, pos, Quaternion.identity);
            gameState.enemyObjects.Add(enemy);
            StartCoroutine(DeleteArrow(minRareDelete, maxRareDelete, enemy));
        }
    }
    IEnumerator DeleteArrow(float minTime, float maxTime, GameObject enemy)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (gameState.enemyObjects.Count != 0)
        {
            gameState.enemyObjects.RemoveAt(0);
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }


}
