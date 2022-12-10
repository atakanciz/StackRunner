using NaughtyAttributes;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField, Expandable] private GameSettings gameSettings;
    public static GameSettings GameSettings => Instance.gameSettings;
    
    public static SettingsManager Instance;
    private void Awake()
    {
        Instance = this;
    }
}