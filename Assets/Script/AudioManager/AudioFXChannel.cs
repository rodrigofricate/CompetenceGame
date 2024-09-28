using Assets.Script.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFXChannel : MonoBehaviour
{
    public AudioSource FXAudioSource;
    [Header("FX")]
    public AudioClip CorrectAnsware;
    public AudioClip WrongAnsware;
    public AudioClip RollDice;
    public AudioClip FootSteps;
    public AudioClip Whoosh;
    public AudioClip CheckAnsware;
    public AudioClip ClockThick;
    public AudioClip GetFX(EnumAudioClip fxAudio)
    {
        switch (fxAudio)
        {
            case EnumAudioClip.CorrectAnsware: return CorrectAnsware;
            case EnumAudioClip.WrongAnsware: return WrongAnsware;
            case EnumAudioClip.RollDice: return RollDice;
            case EnumAudioClip.Whoosh: return Whoosh;
            case EnumAudioClip.CheckAnsware: return CheckAnsware;
            case EnumAudioClip.ClockThick: return ClockThick;
        }

        throw new InvalidOperationException("Audio não encontrado!");


    }


}
