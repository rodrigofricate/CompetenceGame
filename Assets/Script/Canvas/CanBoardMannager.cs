using Assets.Script;
using Assets.Script.Canvas;
using Assets.Script.Enums;
using Assets.Script.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanBoardMannager : MonoBehaviour
{
    QuestionPool questionPool = new QuestionPool();

    [SerializeField] CanOptions_Presenter canOptions;
    [SerializeField] GameObject canConfirmExit;
    [Header("Question Canvas Actions")]
    [SerializeField] CanCompetence_Presenter canQuestions;
    ICompetenceCard currentCompetenceCard;

    [Header("Challange Canvas Actions")]
    [SerializeField] CanChallange_Presenter canChallange;
    IChallangeCard currentChallangeCard;

    [Header("End Game Canvas")]
    [SerializeField] CanEndGame canEndGame;

    [Header("TimeLine Canvas")]
    [SerializeField] CanTimeLine canTimeLine;
    // Start is called before the first frame update
    void Start()
    {

        canEndGame.gameObject.SetActive(false);
        canQuestions.DisableCanva();
        canChallange.DisableCanva();
        canOptions.gameObject.SetActive(false);
        canConfirmExit.SetActive(false);
        RefreshCanvasTimeLine(Board.Instance.GetPlayerTurnManager());
        EnableCanQuestion();

    }

    private void Update()
    {
        SceneInputs();
    }


    #region Competence Buttons
    public void BttAnswareA()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }
        EnumCompetenceAnsware selectedAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;
        StartCoroutine(AnswareEffect(selectedAnsware));
    }
    public void BttAnswareB()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }

        EnumCompetenceAnsware selectedAnsware = EnumCompetenceAnsware.HabilidadeDigital;
        StartCoroutine(AnswareEffect(selectedAnsware));
    }
    public void BttAnswareC()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }

        EnumCompetenceAnsware selectedAnsware = EnumCompetenceAnsware.Inovação;
        StartCoroutine(AnswareEffect(selectedAnsware));
    }
    public void BttAnswareD()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }

        EnumCompetenceAnsware selectedAnsware = EnumCompetenceAnsware.Coragem;
        StartCoroutine(AnswareEffect(selectedAnsware));
    }

    #endregion

    #region Challange Buttons
    public void BttCorrectChallange()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }
        canChallange.DisableCanva();

        AudioManager.instance.PlayFXAudio(EnumAudioClip.CorrectAnsware);

        Board.Instance.GetDice().PrepareToRollDice();
        BoardCameraVM.Instance.SetCameraToDicePosition();
    }
    public void BttWrongChallange()
    {
        if (canOptions.gameObject.activeInHierarchy) { return; }
        canChallange.DisableCanva();

        AudioManager.instance.PlayFXAudio(EnumAudioClip.WrongAnsware);

        Board.Instance.GetCurrentPlayer().GetComponent<Player>().WrongQuestion();
    }

    #endregion

    void EnableCanQuestion()
    {

        currentCompetenceCard = questionPool.DrawRandomCompetenceCard();
        canQuestions.QuestionText.text = currentCompetenceCard.GetTitle();
        canQuestions.QuestionNumberText.text = currentCompetenceCard.GetNumber();
        foreach (Button btt in canQuestions.BttAnswares) { btt.interactable = true; }
        canQuestions.EnableCanva();
    }
    void EnableCanChallange()
    {
        currentChallangeCard = questionPool.DrawRandomChallangeCard();
        canChallange.challangeQuestion.text = currentChallangeCard.GetChallangeQuestion();
        canChallange.EnableCanva();
    }
    public void EnableQuestion(EnumFloorType floorType)
    {
        if (floorType == EnumFloorType.CompetenceQuestion)
        {
            EnableCanQuestion();
        }
        else if (floorType == EnumFloorType.Challange)
        {
            EnableCanChallange();
        }
        else
        {
            Debug.LogError("FloorType não encontrado!");
        }
    }
    public void EnableCanEndGame()
    {
        canEndGame.gameObject.SetActive(true);
    }
    public void RefreshCanvasTimeLine(PlayerTurnManager turnManager)
    {
        GameObject[] playersTimeLine = turnManager.GetPlayersTimeline();
        GameObject currentPlayer = turnManager.GetCurrentPlayer();
        for (int i = 0; i < canTimeLine.GetPortraitArray().Length; i++)
        {
            if (i >= playersTimeLine.Length)
            {
                canTimeLine.GetPortraitArray()[i].gameObject.SetActive(false);
            }
            else if (playersTimeLine[i] == currentPlayer)
            {
                canTimeLine.GetPortraitArray()[i].sprite = currentPlayer.GetComponent<Player>().GetPortrait();
                canTimeLine.GetPortraitArray()[i].color = Color.white;
            }
            else
            {
                canTimeLine.GetPortraitArray()[i].sprite = playersTimeLine[i].GetComponent<Player>().GetPortrait();
                canTimeLine.GetPortraitArray()[i].color = canTimeLine.GetOffTimeColor();
            }

        }


    }

    //Rotinas
    IEnumerator AnswareEffect(EnumCompetenceAnsware selectedAnsware)
    {
        AudioManager.instance.StopClockThickFX();
        AudioManager.instance.PlayFXAudio(EnumAudioClip.CheckAnsware);

        canQuestions.StopChronometer = true;
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);
        int numberOfEffectTimes = 0;
        foreach (Button btt in canQuestions.BttAnswares) { btt.interactable = false; }

        //GFX das questões
        while (numberOfEffectTimes < 2)
        {
            for (int i = 0; i < canQuestions.Answares.Length; i++)
            {
                canQuestions.Answares[i].color = Color.yellow;
                yield return waitTime;
                canQuestions.Answares[i].color = Color.white;
            }
            numberOfEffectTimes++;
            yield return null;
        }

        canQuestions.Answares[(int)selectedAnsware].color = Color.red;
        canQuestions.Answares[(int)currentCompetenceCard.GetRigthAnsware()].color = Color.green;
        waitTime = new WaitForSeconds(3f);
        yield return waitTime;

        foreach (Image obj in canQuestions.Answares)
        {
            obj.color = Color.white;
        }
        canQuestions.DisableCanva();

        //Acerto e Erro
        if (selectedAnsware == currentCompetenceCard.GetRigthAnsware())
        {
            AudioManager.instance.PlayFXAudio(EnumAudioClip.CorrectAnsware);
            Board.Instance.GetDice().PrepareToRollDice();
            BoardCameraVM.Instance.SetCameraToDicePosition();
        }
        else
        {
            AudioManager.instance.PlayFXAudio(EnumAudioClip.WrongAnsware);
            Board.Instance.GetCurrentPlayer().GetComponent<Player>().WrongQuestion();
        }
    }


    void SceneInputs()
    {
        //Opções
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canConfirmExit.activeInHierarchy)
            {
                AudioManager.instance.PlayUIClick();
                canOptions.DisableExitCanva();
                return;
            }
            if (canOptions.gameObject.activeInHierarchy)
            {
                AudioManager.instance.PlayUIClick();
                canOptions.DisbaleOptions();
                return;
            }
            if (!canOptions.gameObject.activeInHierarchy)
            {
                AudioManager.instance.PlayUIClick();
                canOptions.EnableOptions();
                return;
            }
        }
        //Tempo
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (FakeSaveSystem.AnswareTime < 180)
            {
                FakeSaveSystem.AnswareTime += 30;
            }

        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (FakeSaveSystem.AnswareTime > 0)
            {
                FakeSaveSystem.AnswareTime -= 30;
            }
        }
        //Questões
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (canQuestions.gameObject.activeInHierarchy)
            {
                if (canQuestions.BttAnswares[0].IsInteractable())
                {
                    BttAnswareA();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (canQuestions.gameObject.activeInHierarchy)
            {
                if (canQuestions.BttAnswares[1].IsInteractable())
                {
                    BttAnswareB();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (canQuestions.gameObject.activeInHierarchy)
            {
                if (canQuestions.BttAnswares[2].IsInteractable())
                {
                    BttAnswareC();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (canQuestions.gameObject.activeInHierarchy)
            {
                if (canQuestions.BttAnswares[3].IsInteractable())
                {
                    BttAnswareD();
                }
            }
        }
       
    }
}
