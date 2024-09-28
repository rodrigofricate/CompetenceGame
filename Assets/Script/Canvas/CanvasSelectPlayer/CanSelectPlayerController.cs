using Assets.Script;
using Assets.Script.Canvas;
using Assets.Script.Enums;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanSelectPlayerController : MonoBehaviour
{
    [SerializeField] PlayersWhell playersWhell;

    [SerializeField] GameObject canExitGameConfirm;
    [SerializeField] CanOptions_Presenter canOptions;
    [SerializeField] CanSelectChar_Presenter canSelectChar;

    int selectPos = 0;
    private void Awake()
    {
        canExitGameConfirm.SetActive(false);
        canOptions.gameObject.SetActive(false);
        canSelectChar.confirmElements.SetActive(false);
        foreach (Image portrait in canSelectChar.portraitFrame) { portrait.gameObject.SetActive(false); }
    }
    // Start is called before the first frame update
    void Start()
    {

        canSelectChar.tmpCharName.text = playersWhell.GetCurrentChar().GetPlayerName();
        playersWhell.GetDice().actionAfterRollDice = GoToPlayerSelect;
    }

    // Update is called once per frame
    void Update()
    {
        SceneInputs();
    }

    public void Btt_RotateWhellToRigth()
    {
      
        playersWhell.RotareWhellToRigth();

        AudioManager.instance.PlayFXAudio(EnumAudioClip.Whoosh);

        PlayerAtributes _currentChar = GetPlayerAtribute(playersWhell.GetCurrentChar());
        canSelectChar.tmpCharName.text = _currentChar.PlayerName;

        if (FakeSaveSystem.ContainPlayer(_currentChar))
        {
            canSelectChar.tmpCharName.color = Color.grey;
            canSelectChar.bttSelectPlayer.interactable = false;

        }
        else
        {
            canSelectChar.tmpCharName.color = Color.black;
            canSelectChar.bttSelectPlayer.interactable = true;
        }

    }
    public void Btt_RotateWhellToLeft()
    {

        playersWhell.RotareWhellToLeft();

        AudioManager.instance.PlayFXAudio(EnumAudioClip.Whoosh);

        PlayerAtributes _currentChar = GetPlayerAtribute(playersWhell.GetCurrentChar());
        canSelectChar.tmpCharName.text = _currentChar.PlayerName;
        if (FakeSaveSystem.ContainPlayer(_currentChar))
        {
          
            canSelectChar.tmpCharName.color = Color.grey;
            canSelectChar.bttSelectPlayer.interactable = false;
        }
        else
        {
            canSelectChar.tmpCharName.color = Color.black;
            canSelectChar.bttSelectPlayer.interactable = true;
        }

    }
    public void Btt_SelectPlayer()
    {

        if (FakeSaveSystem.PlayerAtributes.Count < FakeSaveSystem.NumberOfPlayers)
        {
            PlayerAtributes _currentChar = GetPlayerAtribute(playersWhell.GetCurrentChar());
            if (!FakeSaveSystem.ContainPlayer(_currentChar))
            {

               FakeSaveSystem.PlayerAtributes.Add(_currentChar);

                canSelectChar.charsPortrait[selectPos].sprite = FakeSaveSystem.PlayerAtributes[selectPos].Portrait;
                canSelectChar.tmpPortrait[selectPos].text = FakeSaveSystem.PlayerAtributes[selectPos].PlayerName;
                canSelectChar.portraitFrame[selectPos].gameObject.SetActive(true);
                //Restrições de canvas
                canSelectChar.tmpCharName.color = Color.grey;
                canSelectChar.bttSelectPlayer.interactable = false;
                //Gatilho do dado
                SelectCharVMCamera.Instance.SetDicePosition();
                canSelectChar.bottonButtons.SetActive(false);
                playersWhell.GetDice().PrepareToRollDice();
            }
        }


    }
    public void Btt_UndoSelection()
    {
        foreach (TMP_Text tmp in canSelectChar.tmpInitiative) { tmp.gameObject.SetActive(false); }
        foreach (Image portrait in canSelectChar.portraitFrame) { portrait.gameObject.SetActive(false); }
        FakeSaveSystem.PlayerAtributes.Clear();     
        selectPos = 0;

        canSelectChar.tmpCharName.color = Color.black;
        canSelectChar.bttSelectPlayer.interactable = true;
        canSelectChar.bottonButtons.SetActive(true);
        canSelectChar.img_CharName.gameObject.SetActive(true);
        canSelectChar.confirmElements.SetActive(false);
    }
    void GoToPlayerSelect()
    {
        FakeSaveSystem.PlayerAtributes[selectPos].Initiative = playersWhell.GetDice().GetRollValue();
        canSelectChar.tmpInitiative[selectPos].text = FakeSaveSystem.PlayerAtributes[selectPos].Initiative.ToString();
        selectPos++;
        OrderTimeLine();
        SelectCharVMCamera.Instance.SetPlayerPosition();
        canSelectChar.bottonButtons.SetActive(true);
        if (FakeSaveSystem.PlayerAtributes.Count == FakeSaveSystem.NumberOfPlayers) { EnableConfirmElements(); }
    }
    void OrderTimeLine()
    {
       FakeSaveSystem.PlayerAtributes = FakeSaveSystem.PlayerAtributes.OrderByDescending(x => x.Initiative).ToList();
        for (int i = 0; i < FakeSaveSystem.PlayerAtributes.Count; i++)
        {
            canSelectChar.tmpPortrait[i].text = FakeSaveSystem.PlayerAtributes[i].PlayerName;
            canSelectChar.tmpInitiative[i].text = FakeSaveSystem.PlayerAtributes[i].Initiative.ToString();
            canSelectChar.charsPortrait[i].sprite = FakeSaveSystem.PlayerAtributes[i].Portrait;
        }
    }
    void EnableConfirmElements()
    {
        canSelectChar.bottonButtons.SetActive(false);
        canSelectChar.img_CharName.gameObject.SetActive(false);
        canSelectChar.confirmElements.SetActive(true);
    }
    void SceneInputs()
    {
        //Opções
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canExitGameConfirm.activeInHierarchy)
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
        if (canSelectChar.bottonButtons.gameObject.activeInHierarchy && !canOptions.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Btt_RotateWhellToRigth();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Btt_RotateWhellToLeft();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Btt_SelectPlayer();
            }
        }
    }
    PlayerAtributes GetPlayerAtribute(Player player)
    {
        PlayerAtributes _playerAtributes = new PlayerAtributes();
        _playerAtributes.PlayerName = player.GetPlayerName();
        _playerAtributes.Portrait = player.GetPortrait();
        _playerAtributes.PlayerReference = player.GetPlayerReference();
        _playerAtributes.Initiative = 0;
        return _playerAtributes;


    }
}
