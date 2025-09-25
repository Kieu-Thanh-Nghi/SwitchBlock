using System;
using UnityEngine;

public class SoundStore : MonoBehaviour
{
    [SerializeField] AudioSource gameplayBackGround, gameoverBackGround, dragSound;
    [SerializeField] AudioSource plusPoint, diamond, explotion, rocket, switchColor, x2AndMagnet;
    [SerializeField] AudioSource stoneBreak, rockCollapse;

    internal void PlayPlusPoint() => plusPoint?.Play();

    internal void PlayPlusDiamond() => diamond?.Play();

    internal void PlayDragSound()
    {
        if (!dragSound.isPlaying)
        {
            dragSound?.Play();
        }
    }

    internal void PlayGameOverSound(bool isTurnOn) => playContiueSound(gameoverBackGround, isTurnOn);

    internal void PlaySwitchState() => switchColor?.Play();

    internal void PlayExplode() => explotion?.Play();

    internal void PlayGameSound(bool isTurnOn) => playContiueSound(gameplayBackGround, isTurnOn);

    void playContiueSound(AudioSource audio, bool isTurnOn)
    {
        if (isTurnOn) audio?.Play();
        else audio?.Stop();
    }

    internal void PlayDieSound()
    {
        stoneBreak?.Play();
        rockCollapse?.Play();
    }

    internal void PlayX2AndMagnetSound(bool isTurnOn) => playContiueSound(x2AndMagnet, isTurnOn);

    internal void PlayRocketSound() => rocket?.Play();
}
