using UnityEngine.SceneManagement;
using UnityEngine;

public class UIContrler : MonoBehaviour
{
    [SerializeField] GameObject howToPlay, 
        statistics, settings, upgrades,
        skinStore;

    public void ToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    [ContextMenu("aa")]
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
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
