using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoSingleton<RoadManager>
{
    private Cube currentCube;
    private Cube nextCube;
    
    
    public void CreateNextCube(Cube currentCube)
    {
        InputManager.Instance.AbleToTouch = true;
        this.currentCube = currentCube;
        GameObject cube = ObjectPoolManager.Instance.GetCube();
        nextCube = cube.GetComponent<Cube>();
        nextCube.transform.position = currentCube.transform.position + Vector3.forward * nextCube.VisualTransform.localScale.z;
        nextCube.VisualTransform.localScale = currentCube.VisualTransform.localScale;
        nextCube.Initialize();
    }

    public void CubePlacementRoutine()
    {
        InputManager.Instance.AbleToTouch = false;
        if (CheckXPlacementDifference())
        {
            currentCube.DisableEndCollider();
            nextCube.OnPlacement(currentCube);
            currentCube = nextCube;
        }
        else
        {
            GameManager.Instance.GameOver();
            //Destroy
        }
    }

    private bool CheckXPlacementDifference()
    {
        //Check if nextCube touching the currentCube
        return true;
    }
}
