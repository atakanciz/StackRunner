using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool ableToTouch;
    public bool AbleToTouch
    {
        get => ableToTouch;
        set => ableToTouch = value;
    }
    
    public static InputManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        LeanTouch.OnFingerDown += Tap;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= Tap;
    }

    private void Tap(LeanFinger finger)
    {
        if (GameManager.CurrentState == GameStates.Gameplay && ableToTouch)
        {
            GameEvents.Instance.CubePlacementTrigger();
            //RoadManager.Instance.CubePlacementRoutine();
        }
    }
}
