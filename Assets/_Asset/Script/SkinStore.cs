using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SkinStore : MonoBehaviour
{
    [SerializeField] LoadData data;
    [SerializeField] internal string path;
    [SerializeField] Buysell buysell;
    [SerializeField] internal Skin[] skins;
    [SerializeField] SkinStates skinStates;
    Skin usingSkin, newSkinSelected;
    string fileName = "SkinData.json";

    [ContextMenu("setup")]
    internal void Setup()
    {
        path = Path.Combine(Application.persistentDataPath, fileName);
        skinStates.states.Clear();
        skins = GetComponentsInChildren<Skin>();
        int i = 0;
        foreach(var skin in skins)
        {
            skinStates.states.Add(skin.skinState);
            skin.index = i;
            if (skin.skinState == 0) skinStates.usingSkinIndex = i;
            i++;
        }
        saveSkinData();
    }

    void saveSkinData()
    {
        string skinDataJson = JsonUtility.ToJson(skinStates);
        Debug.Log(skinDataJson);
        File.WriteAllText(path, skinDataJson);
    }

    private void Awake()
    {
        foreach (var skin in skins)
        {
            skin.fetchProduct();
        }
    }

    public void config()
    {
        string skinDataJson = File.ReadAllText(path);
        skinStates = JsonUtility.FromJson<SkinStates>(skinDataJson);
        int i = 0;
        foreach (var skin in skins)
        {
            skin.SetupState(skinStates.states[i]);
            skin.setStore(this);
            i++;
        }
        usingSkin = skins[skinStates.usingSkinIndex];
        data.SetUpNewPlayerSkin(skins[skinStates.usingSkinIndex].GetComponentInChildren<SkinToPlay>());
    }

    public void UnlockSkin(Skin theSkin)
    {
        newSkinSelected = theSkin;
        switch (newSkinSelected.skinState)
        {
            case 1:
                UseNewSkin(newSkinSelected);
                break;
            case 2:
                buysell.DoAfterAD += DoAfter;
                buysell.WatchAD(true);
                break;
            case 3:
                buysell.DoAfterPayMoney += DoAfter;
                buysell.PayMoneyForSkin(theSkin);
                break;
        }
    }

    void UseNewSkin(Skin newSkin)
    {
        usingSkin.SetupState(1, true);
        skinStates.states[usingSkin.index] = 1;
        newSkin.SetupState(0, true);
        skinStates.states[newSkin.index] = 0;
        usingSkin = newSkin;
        skinStates.usingSkinIndex = newSkin.index;
        data.SetUpNewPlayerSkin(skins[newSkin.index].GetComponentInChildren<SkinToPlay>());
        saveSkinData();
    }

    void DoAfter()
    {
        UseNewSkin(newSkinSelected);
    }
}

[Serializable]
class SkinStates
{
    [SerializeField] internal List<int> states = new();
    [SerializeField] internal int usingSkinIndex;
}
