using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    public GameObject cubePrefab;
    public Transform cubePoolParent;

    [HideInInspector] public List<GameObject> pooledCubeToRelease;

    public ObjectPoolSystem<GameObject> CubePool;

    private void Awake()
    {
        InitCubePool();
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
    
}