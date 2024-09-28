using Assets.Script.Enums;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioListener audioListener;
    [Header("Canais de som")]
    [SerializeField] AudioMusicChannel musicChannel;
    [SerializeField] AudioFXChannel fXChannel;
    [SerializeField] AudioUIChannel uIChannel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetMute(FakeSaveSystem.IsMute);
        SetMasterVolume(FakeSaveSystem.MasterVolume);
        SetMusicVolume(FakeSaveSystem.MusicVolume);
        SetFxVolume(FakeSaveSystem.FxVolume);
        SetUIVolume(FakeSaveSystem.UIVolume);
        PlayMusic();
    }

    public void SetMute(bool mute)
    {
        FakeSaveSystem.IsMute = mute;

        if (mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }

    }
    public void SetMasterVolume(float volume)
    {
        FakeSaveSystem.MasterVolume = volume;
        volume = Mathf.Clamp( 20.0f * Mathf.Log10(volume),-80,80);
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        FakeSaveSystem.MusicVolume = volume;
        volume = Mathf.Clamp(20.0f * Mathf.Log10(volume), -80, 80);
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetFxVolume(float volume)
    {
        FakeSaveSystem.FxVolume = volume;
        volume = Mathf.Clamp(20.0f * Mathf.Log10(volume), -80, 80);
        audioMixer.SetFloat("FXSoundVolume", volume);
    }
    public void SetUIVolume(float volume)
    {
        FakeSaveSystem.UIVolume = volume;
        volume = Mathf.Clamp(20.0f * Mathf.Log10(volume), -80, 80);
        audioMixer.SetFloat("UIVolume", volume);
    }


    public void PlayUIClick()
    {
        uIChannel.UIAudioSource.clip = uIChannel.ClickUI;
        uIChannel.UIAudioSource.Play();
    }
    //FX
    public void PlayFXAudio(EnumAudioClip referenceFX)
    {
        fXChannel.FXAudioSource.clip = fXChannel.GetFX(referenceFX);
        fXChannel.FXAudioSource.Play();
    }
    public void PlayFootStepsFX()
    {
        fXChannel.FXAudioSource.loop = true;
        fXChannel.FXAudioSource.clip = fXChannel.FootSteps;
        fXChannel.FXAudioSource.Play();
    }
    public void StopFootStepsFX()
    {
        fXChannel.FXAudioSource.Stop();
        fXChannel.FXAudioSource.loop = false;
        fXChannel.FXAudioSource.clip = null;
    }
    public void PlayClockThickFX()
    {
        fXChannel.FXAudioSource.loop = true;
        fXChannel.FXAudioSource.clip = fXChannel.ClockThick;
        fXChannel.FXAudioSource.Play();
    }
    public void StopClockThickFX()
    {
        fXChannel.FXAudioSource.Stop();
        fXChannel.FXAudioSource.loop = false;
        fXChannel.FXAudioSource.clip = null;

    }
    void PlayMusic()
    {
        musicChannel.MusicAudioSource.clip = musicChannel.boardMusic;
        musicChannel.MusicAudioSource.loop = true;
        musicChannel.MusicAudioSource.Play();
    }

}
