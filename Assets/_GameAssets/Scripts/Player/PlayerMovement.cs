using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerVisual;
    [SerializeField] private Transform endGameRotationPoint;
    
    private GameSettings settings => SettingsManager.GameSettings;
    private float playerSpeed => settings.PlayerSpeed;

    private void Start()
    {
        GameEvents.Instance.onCubePlacementComplete += SetPositionX;
        
        endGameRotationPoint.DORotate(Vector3.up * 180f, 4f)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }

    private void Update()
    {
        if (GameManager.CurrentState == GameStates.Gameplay)
        {
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
    }

    public void SetPositionX(float x)
    {
        playerVisual.DOMoveX(x, .2f).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        GameEvents.Instance.onCubePlacementComplete -= SetPositionX;
    }
}
