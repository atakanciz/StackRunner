using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum PanelType
{
    LoadingPanel,
    MainMenuPanel,
    GameplayPanel,
}

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private BasePanel mainMenuPanel, gameplayPanel;

    [SerializeField] private List<TextMeshProUGUI> moneyTexts;

    private List<BasePanel> panels = new List<BasePanel>();
    private Dictionary<PanelType, BasePanel> panelDictionary = new Dictionary<PanelType, BasePanel>();

    public BasePanel MainMenuPanel => mainMenuPanel;
    public BasePanel GameplayPanel => gameplayPanel;

    public void Initialize()
    {
        CreateDictionary();
        
        panels.AddRange(new[]
        {
            mainMenuPanel, gameplayPanel
        });

        DeactivateAllPanels();
        ActivatePanel(PanelType.LoadingPanel);
        UpdateMoneyText();
    }

    private void CreateDictionary()
    {
        panelDictionary.Add(PanelType.MainMenuPanel, mainMenuPanel);
        panelDictionary.Add(PanelType.GameplayPanel, gameplayPanel);
    }

    private void OnEnable()
    {
        SaveData.OnCurrentMoneyUpdated += UpdateMoneyText;
    }

    private void OnDisable()
    {
        SaveData.OnCurrentMoneyUpdated -= UpdateMoneyText;
    }

    public void UpdateMoneyText()
    {
        foreach (var text in moneyTexts)
        {
            text.text = $"{SaveData.CurrentMoney}";
        }
    }

    #region Panel Actions
    
    public void ActivatePanel(PanelType type)
    {
        if(!panelDictionary.ContainsKey(type)) 
            return;
        
        panelDictionary[type].gameObject.SetActive(true);

    }
    
    public void DeactivatePanel(PanelType type)
    {
        if(!panelDictionary.ContainsKey(type)) 
            return;
        
        panelDictionary[type].gameObject.SetActive(false);
    }
    
    public void DeactivateAllPanels()
    {
        foreach (var item in panels)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    public void SwitchPanels(PanelType close, PanelType open)
    {
        DeactivatePanel(close);
        ActivatePanel(open);
    }
    
    #endregion

}
