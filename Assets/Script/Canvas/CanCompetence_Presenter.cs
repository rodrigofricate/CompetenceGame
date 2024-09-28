
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Script.Enums;

public class CanCompetence_Presenter : MonoBehaviour
{
    public Image Question;
    public TMP_Text QuestionText;
    public TMP_Text QuestionNumberText;
    public Image[] Answares;
    public Button[] BttAnswares;
    public Image StopWatch;
    public Image StopWatchCover;
    float currentTime;
    bool isInfinity = false;
    [HideInInspector] public bool StopChronometer = false;
    private void Awake()
    {
        if (FakeSaveSystem.AnswareTime <= 0 || FakeSaveSystem.AnswareTime >= 180) { isInfinity = true; }
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
            StopWatchCover.fillAmount = currentTime / FakeSaveSystem.AnswareTime;
            if(currentTime>= FakeSaveSystem.AnswareTime) { TimeEnd(); }
        }
    }
    void TimeEnd()
    {
        foreach (Image obj in Answares)
        {
            obj.color = Color.white;
        }
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
