using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static string keyName = "Sound";
    int maxSound = 3;
    private void Awake()
    {
        if (PlayerPrefs.HasKey(keyName)) return;
        PlayerPrefs.SetInt(keyName, 1);
        PlayerPrefs.Save();
    }

    public void SetSound(Transform soundIcons)
    {
        int currentSound = PlayerPrefs.GetInt(keyName);
        soundIcons.GetChild(currentSound - 1).gameObject.SetActive(false);
        if(currentSound == maxSound)
        {
            currentSound = 1;
        }
        else
        {
            currentSound++;
        }
        PlayerPrefs.SetInt(keyName, currentSound);
        soundIcons.GetChild(currentSound - 1).gameObject.SetActive(true);
        PlayerPrefs.Save();
    }
}
