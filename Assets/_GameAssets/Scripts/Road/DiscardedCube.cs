using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardedCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Transform visual;
    [SerializeField] private Rigidbody rb;

    public Transform Visual => visual;

    public void Initialize(Material material)
    {
        mesh.material = material;
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            ObjectPoolManager.Instance.DiscardedCubePool.Release(gameObject);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
    }
}
