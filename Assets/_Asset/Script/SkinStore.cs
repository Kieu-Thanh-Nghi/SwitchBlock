using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SkinStore : MonoBehaviour
{
    [SerializeField] Skin[] skins;
    string path = Path.Combine(Application.streamingAssetsPath, "SkinData.json");
    [SerializeField] SkinStates skinStates;
    private void Reset()
    {
        skins = GetComponentsInChildren<Skin>();
        int i = 0;
        foreach(var skin in skins)
        {
            skinStates.states.Add(skin.skinState);
            skin.setStore(this);
            skin.index = i;
            i++;
        }

        string skinDataJson = JsonUtility.ToJson(skinStates);
        Debug.Log(skinDataJson);
        File.WriteAllText(path, skinDataJson);
    }

    private void Start()
    {
        string skinDataJson = File.ReadAllText(path);
        skinStates = JsonUtility.FromJson<SkinStates>(skinDataJson);
        int i = 0;
        foreach (var skin in skins)
        {
            skin.SetupState(skinStates.states[i]);
            i++;
        }
    }

    public void UnlockSkin(Skin theSkin)
    {

    }
}

[Serializable]
class SkinStates
{
    [SerializeField] internal List<int> states = new();
}
