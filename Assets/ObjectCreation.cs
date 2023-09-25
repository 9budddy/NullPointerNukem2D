using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCreation : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float objectExtraWidth;
    private float objectExtraHeight;
    
    private float playerWidth;
    private float playerHeight;
    [SerializeField] private GameObject player;

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

    [SerializeField] private float minRareHeroCreate = 4f;
    [SerializeField] private float maxRareHeroCreate = 12f;
    [SerializeField] private float minRareHeroDelete = 7f;
    [SerializeField] private float maxRareHeroDelete = 15f;

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
        StartCoroutine(CreateAmerican(minVeryRareCreate, maxVeryRareCreate));
        StartCoroutine(CreateArrow(minRareCreate, maxRareCreate));
        StartCoroutine(CreateEnglish(minRareHeroCreate, maxRareHeroCreate));
        StartCoroutine(CreateGerman(minRareHeroCreate, maxRareHeroCreate));
        StartCoroutine(CreateSwarm(minMediumCreate, maxMediumCreate));
        StartCoroutine(CreatePirate(minMediumCreate, maxMediumCreate));
        StartCoroutine(CreateBrownie(minOftenCreate, maxOftenCreate));
        StartCoroutine(CreatePendant(minOftenCreate, maxOftenCreate));
        StartCoroutine(CreateCookbook(minVeryOftenCreate, maxVeryOftenCreate));
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

        objectExtraWidth = (objectHeight / 16);
        objectExtraHeight = (objectHeight / 16);

        playerWidth = player.transform.GetComponent<BoxCollider2D>().size.x;
        playerHeight = player.transform.GetComponent<BoxCollider2D>().size.y;

        Vector3 viewPos = obj.transform.position;
        viewPos.x = UnityEngine.Random.Range(screenBounds.x * -1 + (objectWidth - objectExtraWidth), screenBounds.x - (objectWidth - objectExtraWidth));
        viewPos.y = UnityEngine.Random.Range(screenBounds.y * -1, screenBounds.y - (objectHeight - objectExtraHeight));


        //if (viewPos.x < transform.position.x + objectWidth * 2 && viewPos.x > transform.position.x - objectWidth * 2) ; // It is within x... respawn &&
        //if (viewPos.y < transform.position.y + objectHeight * 2 && viewPos.y > transform.position.y - objectHeight * 2) ; // It is within y... respawn ||
        //if (viewPos.x > screenBounds.x || viewPos.y > screenBounds.y || viewPos.x < -screenBounds.x || viewPos.y < -screenBounds.y) // It is out of bounds...respawn
        while ((viewPos.x < playerState.position.x + playerWidth * 2 && viewPos.x > playerState.position.x - playerWidth * 2) &&
            (viewPos.y < playerState.position.y + playerHeight * 2 && viewPos.y > playerState.position.y - playerHeight * 2) &&
            (viewPos.x < playerState.position.x + objectWidth * 2 && viewPos.x > playerState.position.x - objectWidth * 2) &&
            (viewPos.y < playerState.position.y + objectHeight * 2 && viewPos.y > playerState.position.y - objectHeight * 2) ||
            (viewPos.x > screenBounds.x || viewPos.y > screenBounds.y || viewPos.x < -screenBounds.x || viewPos.y < -screenBounds.y))
        {
            viewPos.x = UnityEngine.Random.Range(screenBounds.x * -1 + (objectWidth - objectExtraWidth), screenBounds.x - (objectWidth - objectExtraWidth));
            viewPos.y = UnityEngine.Random.Range(screenBounds.y * -1, screenBounds.y - (objectHeight - objectExtraHeight));
        }

        return viewPos;
    }

    //VERY RARE: --------------------------------------------

    IEnumerator CreateAmerican(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(american, null, "box");
            GameObject obj = Instantiate(american, pos, Quaternion.identity);

            StartCoroutine(DeleteAmerican(minVeryRareDelete, maxVeryRareDelete, obj));
        }
    }
    IEnumerator DeleteAmerican(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);        
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    //RARE: -------------------------------------------------
    IEnumerator CreateArrow(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(arrowWidth, arrowHeight, "poly");
            GameObject enemy = Instantiate(arrow, pos, Quaternion.identity);
            gameState.enemyArrows.Add(enemy);
            StartCoroutine(DeleteArrow(minRareDelete, maxRareDelete, enemy));
        }
    }
    IEnumerator DeleteArrow(float minTime, float maxTime, GameObject enemy)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (gameState.enemyArrows.Count != 0)
        {
            gameState.enemyArrows.RemoveAt(0);
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }

    IEnumerator CreateEnglish(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(english, null, "box");
            GameObject obj = Instantiate(english, pos, Quaternion.identity);

            StartCoroutine(DeleteEnglish(minRareHeroDelete, maxRareHeroDelete, obj));
        }
    }
    IEnumerator DeleteEnglish(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    IEnumerator CreateGerman(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(german, null, "box");
            GameObject obj = Instantiate(german, pos, Quaternion.identity);

            StartCoroutine(DeleteGerman(minRareHeroDelete, maxRareHeroDelete, obj));
        }
    }
    IEnumerator DeleteGerman(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (obj != null)
        {
            Destroy(obj);
        }
    }


    //MEDIUM -------------------------------------------------------------

    IEnumerator CreateSwarm(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(swarm, null, "box");
            GameObject enemy = Instantiate(swarm, pos, Quaternion.identity);
            gameState.enemySwarms.Add(enemy);
            StartCoroutine(DeleteSwarm(minMediumDelete, maxMediumDelete, enemy));
        }
    }
    IEnumerator DeleteSwarm(float minTime, float maxTime, GameObject enemy)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (gameState.enemySwarms.Count != 0)
        {
            gameState.enemySwarms.RemoveAt(0);
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }

    IEnumerator CreatePirate(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(pirate, null, "box");
            GameObject enemy = Instantiate(pirate, pos, Quaternion.identity);
            gameState.enemyPirates.Add(enemy);
            StartCoroutine(DeletePirate(minMediumDelete, maxMediumDelete, enemy));
        }
    }
    IEnumerator DeletePirate(float minTime, float maxTime, GameObject enemy)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (gameState.enemyPirates.Count != 0)
        {
            gameState.enemyPirates.RemoveAt(0);
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }


    //OFTEN: ---------------------------------------------------------------------

    IEnumerator CreateBrownie(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(brownie, null, "box");
            GameObject obj = Instantiate(brownie, pos, Quaternion.identity);

            StartCoroutine(DeleteBrownie(minOftenDelete, maxOftenDelete, obj));
        }
    }
    IEnumerator DeleteBrownie(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    IEnumerator CreatePendant(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(pendant, null, "box");
            GameObject obj = Instantiate(pendant, pos, Quaternion.identity);

            StartCoroutine(DeletePendant(minOftenDelete, maxOftenDelete, obj));
        }
    }
    IEnumerator DeletePendant(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (obj != null)
        {
            Destroy(obj);
        }
    }


    //VERY OFTEN: ------------------------------------------------------------------
    IEnumerator CreateCookbook(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = WithinScreen(cookbook, null, "box");
            GameObject obj = Instantiate(cookbook, pos, Quaternion.identity);

            StartCoroutine(DeleteCookbook(minVeryOftenDelete, maxVeryOftenDelete, obj));
        }
    }
    IEnumerator DeleteCookbook(float minTime, float maxTime, GameObject obj)
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
