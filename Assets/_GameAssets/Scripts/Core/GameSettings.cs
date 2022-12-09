using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Core/GameSettings", order = 2)]
public class GameSettings : ScriptableObject
{
    [BoxGroup("Player")] public float PlayerSpeed;
    
    
    [BoxGroup("Cube")] public float CubeMovementSpeed;
    [BoxGroup("Cube")] public float CubeDestructionThreshold;

}