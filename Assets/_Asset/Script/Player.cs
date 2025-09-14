using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] GameObject spriteMask, blink;
    [SerializeField] SkinToPlay skin;
    [SerializeField] SkinImage skinImage;
    [SerializeField] SpriteRenderer skinSprite;
    public static Player Instance { get; private set; }
    internal void SetSkin(SkinToPlay theSkin)
    {
        skin = theSkin;
        skinImage = theSkin.GetComponentInChildren<SkinImage>();
        skinImage.transform.localScale = Vector3.one;
        skinSprite = skinImage.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    internal void SwitchEff(bool isBlack)
    {
        switchSkinImage(isBlack);
        switchParticleColor(isBlack);
    }

    void switchSkinImage(bool isBlack)
    {
        if (isBlack && skin.skinWhenWhiteGround != null)
        {
            skinSprite.sprite = skin.skinWhenWhiteGround;
        }
        if (!isBlack && skin.skinWhenBlackGround != null)
        {
            skinSprite.sprite = skin.skinWhenBlackGround;
        }
    }

    void switchParticleColor(bool isBlack)
    {
        var particleSystemMain = particleSystem.main;
        if (isBlack) particleSystemMain.startColor = skin.colorWhenWhiteGround;
        else particleSystemMain.startColor = skin.colorWhenBlackGround;
    }
}
