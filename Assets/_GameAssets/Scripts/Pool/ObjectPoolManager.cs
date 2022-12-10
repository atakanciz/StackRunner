using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject discardedCubePrefab;
    
    public Transform cubePoolParent;
    public Transform discardedCubePoolParent;

    [HideInInspector] public List<GameObject> pooledCubeToRelease;
    [HideInInspector] public List<GameObject> pooledDiscardedCubeToRelease;

    public ObjectPoolSystem<GameObject> CubePool;
    public ObjectPoolSystem<GameObject> DiscardedCubePool;
    
    public static ObjectPoolManager Instance;
   
    private void Awake()
    {
        Instance = this;
        InitCubePool();
        InitDiscardedCubePool();
    }
    
    private void InitCubePool() =>
        CubePool = new ObjectPoolSystem<GameObject>(() =>
                Instantiate(cubePrefab, cubePoolParent),
            cube => cube.gameObject.SetActive(true),
            cube => cube.gameObject.SetActive(false),
            cube => Destroy(cube.gameObject),
            false, 20, 50);

    public GameObject GetCube()
    {
        GameObject cube = CubePool.Get();
        cube.GetComponent<Cube>().Reset();
        return cube;
    }
    
    private void InitDiscardedCubePool() =>
        DiscardedCubePool = new ObjectPoolSystem<GameObject>(() =>
                Instantiate(discardedCubePrefab, discardedCubePoolParent),
            discardedCube => discardedCube.gameObject.SetActive(true),
            discardedCube => discardedCube.gameObject.SetActive(false),
            discardedCube => Destroy(discardedCube.gameObject),
            false, 20, 50);
    
    public GameObject GetDiscardedCube()
    {
        GameObject discardedCube = DiscardedCubePool.Get();
        discardedCube.GetComponent<DiscardedCube>().Reset();
        return discardedCube;
    }
    
    
}