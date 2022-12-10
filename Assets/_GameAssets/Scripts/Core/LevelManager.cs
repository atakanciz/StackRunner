using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private GameObject finishPrefab;
    [SerializeField, ReorderableList] private List<Level> allLevels;
    
    private Level loadedLevel;
    public Level LoadedLevel => loadedLevel;
    

    public void Create()
    {
        if (allLevels.Count != 0)
        {
            var levelIndex = PlayerPrefs.GetInt("CurrentLevel") % allLevels.Count;
            var currentLevel = allLevels[levelIndex];
            loadedLevel = Instantiate(currentLevel);
            loadedLevel.transform.SetParent(transform);
            CreateFinishPrefab();
        }
    }

    private void CreateFinishPrefab()
    {
        GameObject finish = Instantiate(finishPrefab, transform); 
        finish.transform.position = Vector3.forward * loadedLevel.RoadCubeCount * 4f;
    }
}