using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class SaveData
{
    public static UnityAction OnCurrentMoneyUpdated;

    private const string CurrentMoneyKey = "CurrentMoney";
    public static int CurrentMoney
    {
        get => PlayerPrefs.GetInt(CurrentMoneyKey, 0);
        set
        {
            PlayerPrefs.SetInt(CurrentMoneyKey, value);
        }
    }
    
    private const string CurrentLevelKey = "CurrentLevel";
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt(CurrentLevelKey, 1);
        set
        {
            PlayerPrefs.SetInt(CurrentLevelKey, value);
        }
    }
    
}