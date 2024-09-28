using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanOptions : MonoBehaviour
{
    public bool IsEnable = false;
    [Header("Botões fixos")]
    [SerializeField] GameObject fixedButtons;
    [Header("Opções")]
    [SerializeField] GameObject options;
    [SerializeField] Slider sldAmbientSound;
    [SerializeField] TMP_Text tmpAmbientSaoundPercentage;
    [SerializeField] Slider sldFxSound;
    [SerializeField] TMP_Text tmpFxSaoundPercentage;
    [SerializeField] TMP_Dropdown dropGraphicsQuality;
    [SerializeField] Toggle tgFullScreen;
    [Header("Confirmar Saída")]
    [SerializeField] GameObject confirmExit;

    private void Awake()
    {
        options.SetActive(false);
        confirmExit.SetActive(false);
    }


    private void Update()
    {
        if (!IsEnable)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Btt_EnableOptions();
            }
        }
    }


    public void Sld_ChangeAmbientVolume()
    {
        //AudioManagerOld.Instance.ambientVolume = sldAmbientSound.value;
      //  string _soundValue = (AudioManagerOld.Instance.ambientVolume * 100).ToString("00") + "%";
     //   tmpAmbientSaoundPercentage.text = _soundValue;
    }
    public void Sld_ChangeFXVolume()
    {
    //    AudioManagerOld.Instance.fxVolume = sldFxSound.value;
      //  string _fxValue = (AudioManagerOld.Instance.fxVolume * 100).ToString("00") + "%";
     //   tmpFxSaoundPercentage.text = _fxValue;
        AudioManager.instance.PlayUIClick();

    }

    public void Btt_EnableOptions()
    {
        AudioManager.instance.PlayUIClick();
        AudioManager.instance.PlayUIClick();
        IsEnable = true;

        fixedButtons.SetActive(false);

     //   sldAmbientSound.value = AudioManagerOld.Instance.ambientVolume;
     //   string _soundValue = (AudioManagerOld.Instance.ambientVolume * 100).ToString("00") + "%";
      //  tmpAmbientSaoundPercentage.text = _soundValue;

     //   sldFxSound.value = AudioManagerOld.Instance.fxVolume;
      //  string _fxValue = (AudioManagerOld.Instance.fxVolume * 100).ToString("00") + "%";
      //  tmpFxSaoundPercentage.text = _fxValue;

        dropGraphicsQuality.value = FakeSaveSystem.GraphicsQuality;
        tgFullScreen.isOn = FakeSaveSystem.IsFullScreen;

        options.SetActive(true);

    }
    public void Btt_CloseOptions()
    {
        IsEnable = false;

        AudioManager.instance.PlayUIClick();

        fixedButtons.SetActive(true);
        options.SetActive(false);

    }
    public void Btt_EnableConfirmExit()
    {
        AudioManager.instance.PlayUIClick();

        fixedButtons.SetActive(false);
        options.SetActive(false);
        confirmExit.SetActive(true);

    }
    public void Btt_ExitGame()
    {
        AudioManager.instance.PlayUIClick();
        Application.Quit();

    }
    public void Btt_ReturnToGame()
    {
        AudioManager.instance.PlayUIClick();

        IsEnable = false;

        fixedButtons.SetActive(true);
        options.SetActive(false);
        confirmExit.SetActive(false);
    }
    public void SetGameGraphicsQuality(int qualityIndex)
    {
        FakeSaveSystem.GraphicsQuality = qualityIndex;
        QualitySettings.SetQualityLevel(FakeSaveSystem.GraphicsQuality);
    }
    public void SetGameFullScreen(bool isFullScreen)
    {
        FakeSaveSystem.IsFullScreen = isFullScreen;
        if (FakeSaveSystem.IsFullScreen)
        {
            Resolution res = Screen.currentResolution;
            Screen.SetResolution(res.width, res.height, isFullScreen);
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;

        }
        else
        {
            Screen.SetResolution(1024, 768, isFullScreen);
        }
    }
}
