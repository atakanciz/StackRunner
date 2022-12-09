using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Cube hitCube = other.GetComponentInParent<Cube>();
            if (hitCube.IsPlaced)
            {
                RoadManager.Instance.CreateNextCube(hitCube);
            }
        }

        if (other.CompareTag("EndCollider"))
        {
            rb.isKinematic = false;
            GameManager.Instance.GameOver();
        }

        if (other.CompareTag("Diamond"))
        {
            
        }

        if (other.CompareTag("Coin"))
        {
            
        }

        if (other.CompareTag("StarBoost"))
        {
            
        }
    }
}
