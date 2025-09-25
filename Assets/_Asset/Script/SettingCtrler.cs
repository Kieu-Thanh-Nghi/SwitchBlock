using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCtrler : MonoBehaviour
{
    [SerializeField] Transform soundIcons;
    private void Start()
    {
        int currentSound = PlayerPrefs.GetInt(SoundController.keyName);
        soundIcons.GetChild(currentSound - 1).gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
