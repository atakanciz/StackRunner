using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    
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

        if (other.CompareTag("Collectable"))
        {
            Collectable collectable = other.GetComponent<Collectable>();
            collectable.OnCollect();
        }

        if (other.CompareTag("Finish"))
        {
            playerAnimationController.PlayDance();
            GameManager.Instance.LevelCompleted();
        }
    }
}
