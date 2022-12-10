using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private bool isDefaultCube;
    [SerializeField] private Transform visualTransform;
    [SerializeField] private Collider collider;
    [SerializeField] private Collider endCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private List<Material> materialList;

    private bool isLeftSpawned;
    private bool ableToMove;

    private bool isPlaced;
    public bool IsPlaced => isPlaced || isDefaultCube;

    public Transform VisualTransform => visualTransform;

    private GameSettings settings => SettingsManager.GameSettings;
    private float cubeMovementSpeed => settings.CubeMovementSpeed;
    private float cubeDestructionThreshold => settings.CubeDestructionThreshold;
    
    public void Initialize()
    {
        meshRenderer.material = materialList[Random.Range(0, materialList.Count)];
        
        if (Random.Range(0,2) == 0) //Left Spawn
        {
            isLeftSpawned = true;
            visualTransform.position += Vector3.left * 3f;
        }
        else //Right spawn
        {
            isLeftSpawned = false;
            visualTransform.position += Vector3.right * 3f;
        }

        ableToMove = true;
    }

    private void Update()
    {
        if (ableToMove)
        {
            Movement();
            CheckPlacement();
        }
    }

    private void Movement()
    {
        int operation = isLeftSpawned ? 1 : -1;

        visualTransform.position += cubeMovementSpeed * operation * Vector3.right * Time.deltaTime;
    }

    private void CheckPlacement()
    {
        if (isLeftSpawned)
        {
            if (visualTransform.position.x > cubeDestructionThreshold)
            {
                DestructionWithDiscard(true);
            }
        }
        else
        {
            if (visualTransform.position.x < -cubeDestructionThreshold)
            {
                DestructionWithDiscard(true);
            }
        }
    }

    public void OnPlacement(Cube cube, bool isPerfectFit)
    {
        ableToMove = false;
        isPlaced = true;
        
        float diff = visualTransform.position.x - cube.VisualTransform.position.x;

        if (isPerfectFit)
        {
            diff = 0;
        }
        
        float insideSize = cube.VisualTransform.localScale.x - Mathf.Abs(diff);
        float outsideSize = visualTransform.localScale.x - insideSize;

        float xFixedPosition = cube.VisualTransform.position.x + diff / 2;

        visualTransform.localScale = new Vector3(insideSize, visualTransform.localScale.y, visualTransform.localScale.z);
        visualTransform.position = new Vector3(xFixedPosition, visualTransform.position.y, visualTransform.position.z);

        if (!isPerfectFit)
        {
            GameEvents.Instance.CubePlacementComplete(visualTransform.position.x);
            float direction = diff > 0 ? 1f : -1f;
            float boundary = visualTransform.position.x + (insideSize / 2) * direction;
            float outsideCubeXPos = boundary + (outsideSize / 2) * direction;
        
            DiscardOutsideCube(outsideSize, outsideCubeXPos);
        }
    }

    private void DiscardOutsideCube(float size, float xPos)
    {
        AudioManager.Instance.PlayBrick();
        
        GameObject discardedCubeObj = ObjectPoolManager.Instance.GetDiscardedCube();
        discardedCubeObj.transform.position = transform.position;
        DiscardedCube discardedCube = discardedCubeObj.GetComponentInChildren<DiscardedCube>();
        discardedCube.Visual.localScale = new Vector3(size, visualTransform.localScale.y, visualTransform.localScale.z);
        discardedCube.Visual.position = new Vector3(xPos, visualTransform.position.y, visualTransform.position.z);
        discardedCube.Initialize(meshRenderer.material);
    }

    public void DisableEndCollider()
    {
        endCollider.enabled = false;
    }

    public void DisableColliders()
    {
        collider.enabled = false;
        endCollider.enabled = false;
    }
    
    public void DestructionWithDiscard(bool isDiscardedAll)
    {
        if (isDiscardedAll)
        {
            InputManager.Instance.AbleToTouch = false;
        }

        AudioManager.Instance.PlayBrick();
        
        ObjectPoolManager.Instance.CubePool.Release(gameObject);
        GameObject discardedCubeObj = ObjectPoolManager.Instance.GetDiscardedCube();
        discardedCubeObj.transform.position = transform.position;
        DiscardedCube discardedCube = discardedCubeObj.GetComponentInChildren<DiscardedCube>();
        discardedCube.Visual.localScale = visualTransform.localScale;
        discardedCube.Visual.position = visualTransform.position;
        discardedCube.Initialize(meshRenderer.material);
    }

    public void Reset()
    {
        //Reset all comp of cube
    }
}
