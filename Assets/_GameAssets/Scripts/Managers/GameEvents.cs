using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance; //MonoSingleton is not used on purpose
    private void Awake()
    {
        Instance = this;
    }

    public event Action<float> onCubePlacementComplete;
    public void CubePlacementComplete(float xPos)
    {
        if (onCubePlacementComplete != null)
        {
            onCubePlacementComplete(xPos);
        }
    }
    
    public event Action<Cube> onCreateNextCube;
    public void CreateNextCubeTrigger(Cube cube)
    {
        if (onCreateNextCube != null)
        {
            onCreateNextCube(cube);
        }
    }

    public event Action onCubePlacement;
    public void CubePlacementTrigger()
    {
        if (onCubePlacement != null)
        {
            onCubePlacement();
        }
    }
}
