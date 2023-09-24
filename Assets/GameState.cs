using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gamestate", menuName = "State/JBGameState")]
public class GameState : ScriptableObject
{

    public int browiePoints { get; set; }
    public int points { get; set; }

    public List<GameObject> enemyObjects { get; set; }
}
