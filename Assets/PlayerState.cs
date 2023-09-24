using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerState", menuName = "State/PlayerState")]
public class PlayerState : ScriptableObject
{
    public Vector3 position { get; set; }
}