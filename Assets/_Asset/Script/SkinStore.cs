using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Collections;

public class SkinStore : MonoBehaviour
{
    [SerializeField] string path;
    [SerializeField] Buysell buysell;
    [SerializeField] internal Skin[] skins;
    [SerializeField] SkinStates skinStates;
    Skin usingSkin;

    [ContextMenu("setup")]
    private void Setup()
    {
        path = Path.Combine(Application.persistentDataPath, "SkinData.json");
        skinStates.states.Clear();
        skins = GetComponentsInChildren<Skin>();
        int i = 0;
        foreach(var skin in skins)
        {
            skinStates.states.Add(skin.skinState);
            skin.index = i;
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
        path = Path.Combine(Application.persistentDataPath, "SkinData.json");
        if (File.Exists(path)) return;
        Setup();
    }

    private void Start()
    {
        string skinDataJson = File.ReadAllText(path);
        skinStates = JsonUtility.FromJson<SkinStates>(skinDataJson);
        int i = 0;
        foreach (var skin in skins)
        {
            if(skinStates.states[i] == 0)
            {
                usingSkin = skin;
                Debug.Log(usingSkin);
            }
            skin.SetupState(skinStates.states[i]);
            skin.setStore(this);
            i++;
        }
    }

    public void UnlockSkin(Skin theSkin)
    {
        switch (theSkin.skinState)
        {
            case 1:
                UseNewSkin(theSkin);
                break;
            case 2:
                StartCoroutine(AfterAD(theSkin));
                break;
            case 3:
                StartCoroutine(AfterPayment(theSkin));
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
        saveSkinData();
    }
    IEnumerator AfterAD(Skin newSkin)
    {
        yield return new WaitUntil(() => buysell.WatchAD());
        UseNewSkin(newSkin);
    }
    IEnumerator AfterPayment(Skin newSkin)
    {
        yield return new WaitUntil(() => buysell.PayMoney());
        UseNewSkin(newSkin);
    }
}

[Serializable]
class SkinStates
{
    [SerializeField] internal List<int> states = new();
    [SerializeField] int[] prices = { 0,0,0,0,15000,15000,30000,30000,30000,30000,
    91000,91000,91000,91000,91000,91000,91000};
}
