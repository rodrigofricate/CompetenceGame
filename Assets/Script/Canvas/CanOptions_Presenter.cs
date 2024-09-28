
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Canvas
{
    public class CanOptions_Presenter : MonoBehaviour
    {
        [SerializeField] GameObject CanExitConfirm;
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
        //Som
        public void RefreshMasterVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.MasterVolume * 100).ToString("00") + "%";
            TmpMasterVolumePercentage.text = _soundValue;
        }
        public void RefreshMusicVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.MusicVolume * 100).ToString("00") + "%";
            TmpMusicVolumePercentage.text = _soundValue;
        }
        public void RefreshFXVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.FxVolume * 100).ToString("00") + "%";
            TmpFxVolumePercentage.text = _soundValue;
        }
        public void RefreshUIVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.UIVolume * 100).ToString("00") + "%";
            TmpUIVolumePercentage.text = _soundValue;
        }
        //Next
        public void ExitGame()
        {
            Application.Quit();
        }

        public void DisbaleOptions()
        {
            DisableExitCanva();

            gameObject.SetActive(false);
        }

        public void EnableOptions()
        {
            DisableExitCanva();


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

        public void EnableExitCanva()
        {
            if (CanExitConfirm != null) { CanExitConfirm.gameObject.SetActive(true); }

        }

        public void DisableExitCanva()
        {
            if (CanExitConfirm != null) { CanExitConfirm.gameObject.SetActive(false); }

        }

    }











}
