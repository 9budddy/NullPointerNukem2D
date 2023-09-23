using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    public TextMeshProUGUI knowledgePoints;

    [SerializeField]
    public TextMeshProUGUI browniePoints;
    
    [SerializeField]
    public TextMeshProUGUI knowledgeNeeded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        knowledgeNeeded.text = "Least Knowledge Needed: " + gameState.minimumKnowledgeThreshold.ToString();
        browniePoints.text = "Brownies: " + gameState.minimumKnowledgeThreshold.ToString();
        knowledgePoints.text = "Knowledge: " + gameState.knowledgePoints.ToString();
    }
}
