using UnityEngine;
using UnityEngine.UI;

public class SkillUpgradesCtrler : MonoBehaviour
{
    [SerializeField] GameObject upgradeList, bootsList;
    [SerializeField] GameObject currentList;
    [SerializeField] Image CurrentButtonImage;

    public void TurnOnUpgrade(Image thisButtonImage)
    {
        if (upgradeList.activeSelf) return;
        OnOffButtonImage(thisButtonImage);
        currentList?.SetActive(false);
        upgradeList.SetActive(true);
        currentList = upgradeList;
    }
    public void TurnOnBoosts(Image thisButtonImage) 
    {
        if (bootsList.activeSelf) return;
        OnOffButtonImage(thisButtonImage);
        currentList?.SetActive(false);
        bootsList.SetActive(true);
        currentList = bootsList;
    }

    void OnOffButtonImage(Image thisButtonImage)
    {
        CurrentButtonImage.enabled = false;
        thisButtonImage.enabled = true;
        CurrentButtonImage = thisButtonImage;
    }
}
