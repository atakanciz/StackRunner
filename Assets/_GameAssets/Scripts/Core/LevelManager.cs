using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField, ReorderableList] private List<Level> allLevels;
    private Level loadedLevel;

    public void Create()
    {
        if (allLevels.Count != 0)
        {
            var levelIndex = PlayerPrefs.GetInt("CurrentLevel") % allLevels.Count;
            var currentLevel = allLevels[levelIndex];
            loadedLevel = Instantiate(currentLevel);
            loadedLevel.transform.SetParent(transform);
        }
    }
}