using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image buttonImage;
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private Sprite winButton, loseButton;
    [SerializeField] private Color winColor, loseColor;
    
    public override void Initialize()
    {
        if (GameManager.CurrentState == GameStates.LevelCompleted)
        {
            infoText.text = "YOU WIN !";
            buttonText.text = "Next Level";
            infoText.color = winColor;
            buttonImage.sprite = winButton;
        }
        else
        {
            infoText.text = "YOU FAIL !";
            buttonText.text = "Reload Level";
            infoText.color = loseColor;
            buttonImage.sprite = loseButton;
        }
    }

    public void ReloadButtonClick()
    {
        GameManager.Instance.ReloadLevel();
    }
}
