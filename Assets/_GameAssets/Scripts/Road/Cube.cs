using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private bool isDefaultCube;
    [SerializeField] private Transform visualTransform;
    [SerializeField] private Collider endCollider;
    [SerializeField] private MeshRenderer material;
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
                Destruction();
            }
        }
        else
        {
            if (visualTransform.position.x < -cubeDestructionThreshold)
            {
                Destruction();
            }
        }
    }

    public void OnPlacement(Cube cube)
    {
        ableToMove = false;
        isPlaced = true;
        //Check the difference between cubes => scale change => spawn new cube to drop
    }

    public void DisableEndCollider()
    {
        endCollider.enabled = false;
    }
    
    public void Destruction()
    {
        InputManager.Instance.AbleToTouch = false;
        ObjectPoolManager.Instance.CubePool.Release(gameObject);
    }

    public void Reset()
    {
        //Reset all comp of cube
    }
}
