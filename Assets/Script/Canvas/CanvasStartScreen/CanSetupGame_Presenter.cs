
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanSetupGame_Presenter : MonoBehaviour
{
    [Header("Gameplay Elements")]
    public TMP_Text TmpPlayerNumber;
    public TMP_Text TmpAnswareTime;
    public TMP_Text ChallangeTime;
    [Header("Graphics Elements")]
    public Toggle TgFullScreen;
    public TMP_Dropdown DropGraphicQuality;
    [Header("Audio Elements")]
    public Toggle TgMute;
    public Slider SldMasterVolume;
    public TMP_Text TmpMasterVolumePercentage;
    public Slider SldMusicVolume;
    public TMP_Text TmpMusicVolumePercentage;
    public Slider SldFxVolume;
    public TMP_Text TmpFxVolumePercentage;
    public Slider SldUIVolume;
    public TMP_Text TmpUIVolumePercentage;

    public void EnableCanva()
    {
            //Gameplay
            TmpPlayerNumber.text = FakeSaveSystem.NumberOfPlayers.ToString();
           TmpAnswareTime.text = FakeSaveSystem.AnswareTime.ToString() + "'s";
           ChallangeTime.text = FakeSaveSystem.ChallangeTime.ToString() + "'s";

            //Grafico
            DropGraphicQuality.value = FakeSaveSystem.GraphicsQuality;
            TgFullScreen.isOn = FakeSaveSystem.IsFullScreen;
           TgMute.isOn = FakeSaveSystem.IsMute;

            //Audio
            SldMasterVolume.value = FakeSaveSystem.MasterVolume;
            string _masterValue = (FakeSaveSystem.MasterVolume * 100).ToString("00") + "%";
            TmpMusicVolumePercentage.text = _masterValue;

            SldMusicVolume.value = FakeSaveSystem.MusicVolume;
            string _musicValue = (FakeSaveSystem.MusicVolume * 100).ToString("00") + "%";
            TmpMusicVolumePercentage.text = _musicValue;

            SldFxVolume.value = FakeSaveSystem.FxVolume;
            string _fxValue = (FakeSaveSystem.FxVolume * 100).ToString("00") + "%";
            TmpFxVolumePercentage.text = _fxValue;

            SldUIVolume.value = FakeSaveSystem.UIVolume;
            string _uiValue = (FakeSaveSystem.UIVolume * 100).ToString("00") + "%";
            TmpUIVolumePercentage.text = _uiValue;

            //Enable
            gameObject.SetActive(true);


        

    }

}
