using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;

public enum CameraTypes
{
    MainMenu = 0,
    Gameplay = 1,
    EndGame = 2
}

public class CameraManager : MonoSingleton<CameraManager>
{
    public static Camera MainCamera => Instance.mainCamera;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private CameraTypes defaultCamera;
    [SerializeField] private CinemachineVirtualCamera[] cameras;

    private CameraTypes currentCameraType;
    public CinemachineVirtualCamera CurrentCamera { get; set; }

    private void Start()
    {
        ChangeCamera(defaultCamera);
    }

    private void UpdateCurrentCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            var isCamOn = (int)currentCameraType == i;
            var cam = cameras[i];
            
            if (cam.enabled = isCamOn)
            {
                CurrentCamera = cam;
            }
        }
    }
    
    public static void ChangeCamera(CameraTypes cam)
    {
        Instance.currentCameraType = cam;
        Instance.UpdateCurrentCamera();
    }

    public void SetFocus(Transform transform)
    {
        CurrentCamera.m_Follow = transform;
        CurrentCamera.m_LookAt = transform;
    }
}
