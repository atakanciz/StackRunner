using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    private Cube currentCube;
    private Cube nextCube;
    private int spawnedCubeCount;
    private int perfectFitCounter;
    private bool isPerfectFit;

    private GameSettings settings => SettingsManager.GameSettings;
    private float cubePerfectFitThreshold => settings.CubePerfectFitThreshold;

    private void Start()
    {
        GameEvents.Instance.onCreateNextCube += CreateNextCube;
        GameEvents.Instance.onCubePlacement += CubePlacementRoutine;
    }

    public void CreateNextCube(Cube currentCube)
    {
        InputManager.Instance.AbleToTouch = true;
        this.currentCube = currentCube;
        GameObject cube = ObjectPoolManager.Instance.GetCube();
        nextCube = cube.GetComponent<Cube>();
        nextCube.transform.position = currentCube.transform.position + Vector3.forward * nextCube.VisualTransform.localScale.z;
        nextCube.VisualTransform.localScale = currentCube.VisualTransform.localScale;
        
        spawnedCubeCount++;
        if (LevelManager.Instance.LoadedLevel.RoadCubeCount == spawnedCubeCount)
        {
            nextCube.DisableColliders();
        }
        
        nextCube.Initialize();
    }

    public void CubePlacementRoutine()
    {
        InputManager.Instance.AbleToTouch = false;
        if (CheckXPlacementDifference())
        {
            if (isPerfectFit)
                AudioManager.Instance.PlayNote(1 + 0.05f * perfectFitCounter);
            
            currentCube.DisableEndCollider();
            nextCube.OnPlacement(currentCube,isPerfectFit);
            currentCube = nextCube;
        }
        else
        {
            AudioManager.Instance.PlayBrick();
            nextCube.DestructionWithDiscard(false);
            GameManager.Instance.GameOver();
        }
    }

    private bool CheckXPlacementDifference()
    {
        float diff = nextCube.VisualTransform.position.x - currentCube.VisualTransform.position.x;

        CheckPerfectFit(diff);

        return Mathf.Abs(diff) < currentCube.VisualTransform.localScale.x;
    }

    private void CheckPerfectFit(float diff)
    {
        if (Mathf.Abs(diff) < cubePerfectFitThreshold)
        {
            isPerfectFit = true;
            perfectFitCounter++;
        }
        else
        {
            isPerfectFit = false;
            perfectFitCounter = 0;
        }

    }

    private void OnDisable()
    {
        GameEvents.Instance.onCreateNextCube -= CreateNextCube;
        GameEvents.Instance.onCubePlacement -= CubePlacementRoutine;
    }

}
