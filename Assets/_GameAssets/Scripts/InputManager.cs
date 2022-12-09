using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private bool ableToTouch;
    public bool AbleToTouch
    {
        get => ableToTouch;
        set => ableToTouch = value;
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
        if (ableToTouch)
        {
            RoadManager.Instance.CubePlacementRoutine();
        }
    }
}
