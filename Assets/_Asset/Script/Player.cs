using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SkinToPlay skin;
    SkinImage skinImage;
    [SerializeField] GameObject spriteMask, blink;

    public static Player Instance { get; private set; }
    internal void SetSkin(SkinToPlay theSkin)
    {
        skin = theSkin;
        skinImage = theSkin.GetComponentInChildren<SkinImage>();
        skinImage.transform.localScale = Vector3.one;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }
}
