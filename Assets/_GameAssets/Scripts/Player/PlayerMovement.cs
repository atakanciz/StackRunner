using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerVisual;
    
    private GameSettings settings => SettingsManager.GameSettings;
    private float playerSpeed => settings.PlayerSpeed;
    
    private void Update()
    {
        if (GameManager.CurrentState == GameStates.Gameplay)
        {
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
    }
}
