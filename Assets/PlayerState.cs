using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerState", menuName = "State/PlayerState")]
public class PlayerState : ScriptableObject
{
    public bool rightColliding { set; get; }
    public bool leftColliding { set; get; }
    public bool topColliding { set; get; }
    public bool bottomColliding { set; get; }
}