using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContrler : MonoBehaviour
{
    [SerializeField] GameObject howToPlay, 
        statistics, settings, upgrades,
        skinStore;
    internal void OnOffGameSound()
    {

    }

    public void PopupUpgrades()
    {
        upgrades.SetActive(true);
    }

    public void PopupSettings()
    {
        settings.SetActive(true);
    }

    public void PopupHelp()
    {
        howToPlay.SetActive(true);
    }
    public void PopupStats()
    {
        statistics.SetActive(true);
    }
    public void PopupSkinStore()
    {
        skinStore.SetActive(true);
    }
    internal void QuitGame()
    {
        
    }
    
    public void QuitTheUI(GameObject theUI)
    {
        theUI.SetActive(false);
    }
    
    internal void RateGame()
    {

    }
}
