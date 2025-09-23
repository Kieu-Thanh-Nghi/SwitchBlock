using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal bool isImunity = false;
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] ParticleSystem particleWhenDiePrefab;

    [SerializeField] GameObject spriteMask, blink;
    [SerializeField] float blinkingDuration = 0.5f;
    [SerializeField] int blinkTimes = 2;

    [SerializeField] internal GameObject magnet;
    [SerializeField] SkinToPlay skin;
    [SerializeField] SkinImage skinImage;
    [SerializeField] internal SpriteRenderer skinSprite;
    [SerializeField] internal Vector3 PlayerStartPos;
    ParticleSystem.MainModule particleSystemMain;
    WaitForSeconds blinkDelay;

    private void Awake()
    {
        blinkDelay = new WaitForSeconds(blinkingDuration);
    }

    internal void SetSkin(SkinToPlay theSkin)
    {
        skin = theSkin;
        skinImage = theSkin.GetComponentInChildren<SkinImage>();
        skinImage.transform.localScale = Vector3.one;
        skinSprite = skinImage.GetComponent<SpriteRenderer>();
        changeParticleColor(particleSystem, skin.colorWhenWhiteGround);
        changeParticleColor(particleWhenDiePrefab, skin.colorWhenWhiteGround);
    }

    internal Color GetParticleColor()
    {
        particleSystemMain = particleSystem.main;
        return particleSystemMain.startColor.color;
    }

    internal void Die()
    {
        gameObject.SetActive(false);
        ParticleSystem particleWhenDie = Instantiate(particleWhenDiePrefab, transform.position, transform.rotation);
        changeParticleColor(particleWhenDie, GetParticleColor());
        Destroy(particleWhenDie.gameObject, 2);
    }

    internal void StartBlink()
    {
        StartCoroutine(blinking());
    }

    IEnumerator blinking()
    {
        isImunity = true;
        for(int i = 0; i< blinkTimes; i++)
        {
            spriteMask.SetActive(false);
            blink.SetActive(true);
            yield return blinkDelay;
            spriteMask.SetActive(true);
            blink.SetActive(false);
            yield return blinkDelay;
        }
        isImunity = false;
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
        Color tempColor;
        if (isBlack) tempColor = skin.colorWhenWhiteGround;
        else tempColor = skin.colorWhenBlackGround;
        changeParticleColor(particleSystem, tempColor);
    }

    void changeParticleColor(ParticleSystem ps, Color theColor)
    {
        particleSystemMain = ps.main;
        particleSystemMain.startColor = theColor;
    }
}
