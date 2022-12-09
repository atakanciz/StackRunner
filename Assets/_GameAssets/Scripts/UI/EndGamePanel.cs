using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanel : BasePanel
{
    [SerializeField] private GameObject winPanel, losePanel;
    
    public override void Initialize(GameStates state)
    {
        if (state == GameStates.LevelCompleted)
        {
            winPanel.SetActive(true);
        }
        else if (state == GameStates.GameOver)
        {
            losePanel.SetActive(true);
        }
    }
}
