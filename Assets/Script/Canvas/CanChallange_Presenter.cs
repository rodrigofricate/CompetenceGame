using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Script.Enums;

public class CanChallange_Presenter : MonoBehaviour
{
    public TMP_Text challangeQuestion;
    public Image StopWatch;
    public Image StopWatchCover;
    float currentTime;
    bool isInfinity = false;
    [HideInInspector] public bool StopChronometer = false;


    private void Awake()
    {
        if (FakeSaveSystem.AnswareTime <= 0 || FakeSaveSystem.AnswareTime >= 240) { isInfinity = true; }
    }

    private void FixedUpdate()
    {
        Chronometer();
    }

    void Chronometer()
    {
        if (isInfinity || StopChronometer) { return; }

        if (gameObject.activeInHierarchy)
        {


            currentTime += Time.fixedDeltaTime;
            StopWatchCover.fillAmount = currentTime / FakeSaveSystem.ChallangeTime;
            if (currentTime >= FakeSaveSystem.ChallangeTime) { TimeEnd(); }
        }
    }
    void TimeEnd()
    {

        DisableCanva();

        AudioManager.instance.PlayFXAudio(EnumAudioClip.WrongAnsware);
        Board.Instance.GetCurrentPlayer().GetComponent<Player>().WrongQuestion();
    }

    public void EnableCanva()
    {
        StopChronometer = false;
        if (isInfinity) { StopWatch.gameObject.SetActive(false); }
        if (!isInfinity) { AudioManager.instance.PlayClockThickFX(); }
        gameObject.SetActive(true);
        currentTime = 0;
        StopWatchCover.fillAmount = 0;

    }
    public void DisableCanva()
    {
        if (!isInfinity) { AudioManager.instance.StopClockThickFX(); }
        StopChronometer = true;
        gameObject.SetActive(false);
        currentTime = 0;
        StopWatchCover.fillAmount = 0;
    }
}
