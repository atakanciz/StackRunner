using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Core/GameSettings", order = 2)]
public class GameSettings : ScriptableObject
{
    [BoxGroup("Player")] public float PlayerSpeed;
    [BoxGroup("Player")] public float ProjectileSpeed;
    [BoxGroup("Player")] public float ProjectileYArc;
    [BoxGroup("Player")] public float DefaultFixedDeltaTime;
    [BoxGroup("Player")] public float ProjectileMultiplier;
    
    
    [BoxGroup("Player")] public float PlayerAimMultiplier;
    [BoxGroup("Player")] public float MinForwardRange;
    [BoxGroup("Player")] public float MaxForwardRange;
    [BoxGroup("Player")] public float MinDisplacementAimX;
    [BoxGroup("Player")] public float MaxDisplacementAimX;
    
    
    
    [BoxGroup("Player")] public float PlayerAimMultiplierY;
    [BoxGroup("Player")] public float MinDisplacementAimY;
    [BoxGroup("Player")] public float MaxDisplacementAimY;
    
    
}