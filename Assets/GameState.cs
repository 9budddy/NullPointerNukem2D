using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gamestate", menuName = "State/JBGameState")]
public class GameState : ScriptableObject
{
    public int knowledgePoints { get; set; }
    public int browiePoints { get; set; }
    public int maxKnowledgePoints { get; set; }
    public int minimumKnowledgeThreshold { get; set; }

    public List<GameObject> enemyArrows { get; set; }
    public List<GameObject> enemySwarms { get; set; }
    public List<GameObject> enemyPirates { get; set; }

    public List<GameObject> itemCookbooks { get; set; }
    public List<GameObject> itemPendants { get; set; }
    public List<GameObject> itemBrownies { get; set; }

    public List<GameObject> heroGermans { get; set; }
    public List<GameObject> heroEnglishs { get; set; }
    public List<GameObject> heroAmericans { get; set; }
}
