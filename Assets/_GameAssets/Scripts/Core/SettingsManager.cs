using NaughtyAttributes;
using UnityEngine;

public class SettingsManager : MonoSingleton<SettingsManager>
{
    [SerializeField, Expandable] private GameSettings gameSettings;
    public static GameSettings GameSettings => Instance.gameSettings;
}