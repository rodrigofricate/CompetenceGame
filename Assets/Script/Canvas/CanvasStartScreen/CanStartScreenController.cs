
using UnityEngine;

namespace Assets.Script.Canvas.CanvasStartScreen
{
    public class CanStartScreenController : MonoBehaviour
    {
        [SerializeField] GameObject CanStartScreen;
        [SerializeField] GameObject CanStartAtribuitions;
        [SerializeField] CanSetupGame_Presenter canSetupGame;

        private void Awake()
        {
            CanStartAtribuitions.SetActive(false);
            Resolution systemResolution = Screen.currentResolution;
            Screen.SetResolution(systemResolution.width, systemResolution.height, FakeSaveSystem.IsFullScreen);
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            QualitySettings.SetQualityLevel(FakeSaveSystem.GraphicsQuality);

        }

        private void Start()
        {
            canSetupGame.gameObject.SetActive(false);
        }
        private void Update()
        {
            InputScene();
        }

        //Gameplay
        public void AddPlayer()
        {
            if (FakeSaveSystem.NumberOfPlayers < 4) { FakeSaveSystem.NumberOfPlayers++; }
            canSetupGame.TmpPlayerNumber.text = FakeSaveSystem.NumberOfPlayers.ToString();
        }
        public void RemovePlayer()
        {
            if (FakeSaveSystem.NumberOfPlayers > 2) { FakeSaveSystem.NumberOfPlayers--; }
            canSetupGame.TmpPlayerNumber.text = FakeSaveSystem.NumberOfPlayers.ToString();
        }
        public void AddAnswareTime()
        {
            if (FakeSaveSystem.AnswareTime < 180)
            {
                FakeSaveSystem.AnswareTime += 30;
            }

            if (FakeSaveSystem.AnswareTime >= 180)
            {
                canSetupGame.TmpAnswareTime.text = "Ilimitado";
            }
            else
            {
                canSetupGame.TmpAnswareTime.text = FakeSaveSystem.AnswareTime.ToString() + "'s";
            }

        }
        public void RemoveAnswareTime()
        {
            if (FakeSaveSystem.AnswareTime > 0)
            {
                FakeSaveSystem.AnswareTime -= 30;
            }

            if (FakeSaveSystem.AnswareTime <= 0)
            {
                canSetupGame.TmpAnswareTime.text = "Ilimitado";
            }
            else
            {
                canSetupGame.TmpAnswareTime.text = FakeSaveSystem.AnswareTime.ToString() + "'s";
            }


        }
        public void AddChallangeTime()
        {
            if (FakeSaveSystem.ChallangeTime < 240)
            {
                FakeSaveSystem.ChallangeTime += 30;
            }

            if (FakeSaveSystem.ChallangeTime >= 240)
            {
                canSetupGame.ChallangeTime.text = "Ilimitado";
            }
            else
            {
                canSetupGame.ChallangeTime.text = FakeSaveSystem.ChallangeTime.ToString() + "'s";
            }

        }
        public void RemoveChallangeTime()
        {
            if (FakeSaveSystem.ChallangeTime > 90)
            {
                FakeSaveSystem.ChallangeTime -= 30;
            }

            if (FakeSaveSystem.ChallangeTime <= 90)
            {
                canSetupGame.ChallangeTime.text = "Ilimitado";
            }
            else
            {
                canSetupGame.ChallangeTime.text = FakeSaveSystem.ChallangeTime.ToString() + "'s";
            }


        }
        //Grafico
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
            canSetupGame.TmpMasterVolumePercentage.text = _soundValue;
        }
        public void RefreshMusicVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.MusicVolume * 100).ToString("00") + "%";
            canSetupGame.TmpMusicVolumePercentage.text = _soundValue;
        }
        public void RefreshFXVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.FxVolume * 100).ToString("00") + "%";
            canSetupGame.TmpFxVolumePercentage.text = _soundValue;
        }
        public void RefreshUIVolumePecentage()
        {
            string _soundValue = (FakeSaveSystem.UIVolume * 100).ToString("00") + "%";
            canSetupGame.TmpUIVolumePercentage.text = _soundValue;
        }
        

        public void EnableAtributions()
        {
            CanStartAtribuitions.SetActive(true);
        }
        public void DisbaleAtributions()
        {
            CanStartAtribuitions.SetActive(false);
        }
        public void ExitGame()
        {
            Application.Quit();
        }

        void InputScene()
        {
            if (Input.anyKey)
            {
                if (CanStartScreen.activeInHierarchy)
                {
                    CanStartScreen.SetActive(false);
                    canSetupGame.EnableCanva();
                }
            }
        }
    }
}
