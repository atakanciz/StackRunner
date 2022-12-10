using System;
using System.Collections;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameStates
{
    MainMenu,
    Gameplay,
    GameOver,
    LevelCompleted,
    Wait
}

public class GameManager : MonoSingleton<GameManager>
{
    private GameStates currentState = GameStates.MainMenu;
    public static GameStates CurrentState
    {
        get
        {
            return Instance.currentState;
        }
        set
        {
            Instance.currentState = value;
        }
    }

    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    private IEnumerator Start()
    {
        yield return null;
        CurrentState = GameStates.MainMenu;
        LevelManager.Instance.Create();
        UIManager.Instance.Initialize();
    }

    public void GameStarted()
    {
        CurrentState = GameStates.Gameplay;
        CameraManager.ChangeCamera(CameraTypes.Gameplay);
        UIManager.Instance.SwitchPanels(PanelType.MainMenuPanel, PanelType.GameplayPanel);
    }

    public void GameOver()
    {
        MMVibrationManager.Haptic(HapticTypes.Failure);
        CurrentState = GameStates.GameOver;
        CameraManager.Instance.SetFocus(null);
        UIManager.Instance.SwitchPanels(PanelType.GameplayPanel, PanelType.EndGamePanel);
    }

    public void LevelCompleted()
    {
        CurrentState = GameStates.LevelCompleted;
        SaveData.CurrentLevel++;
        
        MMVibrationManager.Haptic(HapticTypes.Success);
        CameraManager.ChangeCamera(CameraTypes.EndGame);
        UIManager.Instance.SwitchPanels(PanelType.GameplayPanel, PanelType.EndGamePanel);
    }

    public void OnLevelWait()
    {
        CurrentState = GameStates.Wait;
    }

    public void ReloadLevel()
    {
        DOTween.KillAll();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}