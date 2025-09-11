using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgradesCtrler : MonoBehaviour
{
    [SerializeField] GameObject upgradeList, bootsList;
    [SerializeField] GameObject currentList;
    [SerializeField] Image CurrentButtonImage;
    [SerializeField] LoadData data;
    [SerializeField] Buysell buysell;



    PlayerData playerData;
    SkillUpgrade[] listOfUpGrade;
    SkillBoosts[] listOfBoosts;
    private void Awake()
    {
        listOfUpGrade = upgradeList.GetComponentsInChildren<SkillUpgrade>();
        listOfBoosts = bootsList.GetComponentsInChildren<SkillBoosts>();
    }
    private void OnEnable()
    {
        playerData = data.playerData;
        foreach(var aUpgrade in listOfUpGrade)
        {
            aUpgrade.upgradesCtrler = this;
            switch (aUpgrade.skillIndex)
            {
                case 0:
                    setupUpgrade(aUpgrade, playerData.magnet);
                    break;
                case 1:
                    setupUpgrade(aUpgrade, playerData.rocket);
                    break;
                case 2:
                    setupUpgrade(aUpgrade, playerData.x2Mutiplier);
                    break;
            }
        }

        foreach(var aBoosts in listOfBoosts)
        {
            aBoosts.upgradesCtrler = this;
            switch (aBoosts.skillIndex)
            {
                case 0:
                    setupBoosts(aBoosts, playerData.magnet);
                    break;
                case 1:
                    setupBoosts(aBoosts, playerData.rocket);
                    break;
                case 2:
                    setupBoosts(aBoosts, playerData.x2Mutiplier);
                    break;
            }
        }
    }
    internal void DoBoosts(SkillBoosts aBoosts, int withWhat)
    {
        switch (aBoosts.skillIndex)
        {
            case 0:
                BoostsIt(aBoosts, playerData.magnet, withWhat);
                break;
            case 1:
                BoostsIt(aBoosts, playerData.rocket, withWhat);
                break;
            case 2:
                BoostsIt(aBoosts, playerData.x2Mutiplier, withWhat);
                break;
        }
    }
    void BoostsIt(SkillBoosts aBoosts, Skill aSkill, int withWhat)
    {
        switch (withWhat)
        {
            case 0:
                if (aSkill.level > (aSkill.DiamondForEachLvl.Length)) return;
                if (!buysell.PayWithDiamonds(aSkill.DiamondForEachLvl[aSkill.level - 1])) return;
                break;
        }
        if (aSkill.level > (aSkill.DiamondForEachLvl.Length)) return;
        if (!buysell.PayWithDiamonds(aSkill.DiamondForEachLvl[aSkill.level - 1])) return;
        aSkill.level++;
        aSkill.effDuration = aSkill.effDurationPerLvl[aSkill.level - 1];
        data.SavePlayerData();
        setupBoosts(aBoosts, aSkill);
    }
    void setupBoosts(SkillBoosts aBoosts, Skill aSkill)
    {
        aBoosts.useTimes.text = aSkill.Quantity.ToString();
    }
    void setupUpgrade(SkillUpgrade aUpgrade, Skill aSkill)
    {
        aUpgrade.levelText.text = (aSkill.level).ToString();
        aUpgrade.time.text = (aSkill.effDuration).ToString();
        int i = 0;
        foreach (var aProcess in aUpgrade.upgradeProcesses)
        {
            if (i >= aSkill.level) break;
            aProcess.color = aUpgrade.color;
            i++;
        }
    }
    public void TurnOnUpgrade(Image thisButtonImage)
    {
        if (upgradeList.activeSelf) return;
        OnOffButtonImage(thisButtonImage);
        currentList?.SetActive(false);
        upgradeList.SetActive(true);
        currentList = upgradeList;
    }

    internal void DoUpgrade(SkillUpgrade skillUpgrade,int withWhat)
    {
        switch (skillUpgrade.skillIndex)
        {
            case 0:
                upgradeIt(skillUpgrade, playerData.magnet);
                break;
            case 1:
                upgradeIt(skillUpgrade, playerData.rocket);
                break;
            case 2:
                upgradeIt(skillUpgrade, playerData.x2Mutiplier);
                break;
        }
    }

    void upgradeIt(SkillUpgrade aUpgrade, Skill aSkill)
    {
        if (aSkill.level > (aSkill.DiamondForEachLvl.Length)) return;
        if(!buysell.PayWithDiamonds(aSkill.DiamondForEachLvl[aSkill.level - 1])) return;
        aSkill.level++;
        aSkill.effDuration = aSkill.effDurationPerLvl[aSkill.level - 1];
        data.SavePlayerData();
        setupUpgrade(aUpgrade, aSkill);
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
