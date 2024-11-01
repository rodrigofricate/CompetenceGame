using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Script;
using System.Linq;

public class CanSelectChar : MonoBehaviour
{
    [SerializeField] CanOptions canOptions;

    [SerializeField] CanLoadScene canLoadScene;
    [SerializeField] GameObject bottonButtons;
    [SerializeField] GameObject confirmElements;
    [SerializeField] PlayersWhell playersWhell;

    [SerializeField] Image img_CharName;
    [SerializeField] TMP_Text tmpCharName;
    [SerializeField] Button bttSelectPlayer;
    [SerializeField] Image[] portraitFrame;
    [SerializeField] Image[] charsPortrait;
    [SerializeField] TMP_Text[] tmpPortrait;
    [SerializeField] TMP_Text[] tmpInitiative;

    List<GameObject> selectedPlayersList = new List<GameObject>();
    int selectPos = 0;
    List<PlayerAtributes> playerAtributesList = new List<PlayerAtributes>();


    private void Awake()
    {
        foreach (Image portrait in portraitFrame) { portrait.gameObject.SetActive(false); }
    }

    void Start()
    {
        confirmElements.SetActive(false);
        tmpCharName.text = playersWhell.GetCurrentChar().GetPlayerName();
        playersWhell.GetDice().actionAfterRollDice = GoToPlayerSelect;
    }

    private void Update()
    {
        if (bottonButtons.gameObject.activeInHierarchy && !canOptions.IsEnable)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Btt_RotateWhellToRigth();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Btt_RotateWhellToLeft();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                Btt_SelectPlayer();
            }
        }
    }



    public void Btt_RotateWhellToRigth()
    {

        playersWhell.RotareWhellToRigth();
        tmpCharName.text = playersWhell.GetCurrentChar().GetPlayerName();

        if (selectedPlayersList.Contains(playersWhell.GetCurrentChar().gameObject))
        {
            playersWhell.GetSpotligth().gameObject.SetActive(false);
            tmpCharName.color = Color.grey;
            bttSelectPlayer.interactable = false;

        }
        else
        {
            playersWhell.GetSpotligth().gameObject.SetActive(true);
            tmpCharName.color = Color.black;
            bttSelectPlayer.interactable = true;
        }

    }
    public void Btt_RotateWhellToLeft()
    {

        playersWhell.RotareWhellToLeft();
        tmpCharName.text = playersWhell.GetCurrentChar().GetPlayerName();

        if (selectedPlayersList.Contains(playersWhell.GetCurrentChar().gameObject))
        {
            playersWhell.GetSpotligth().gameObject.SetActive(false);
            tmpCharName.color = Color.grey;
            bttSelectPlayer.interactable = false;
        }
        else
        {
            playersWhell.GetSpotligth().gameObject.SetActive(true);
            tmpCharName.color = Color.black;
            bttSelectPlayer.interactable = true;
        }

    }
    public void Btt_SelectPlayer()
    {
        if (selectedPlayersList.Count < FakeSaveSystem.NumberOfPlayers)
        {
            if (!selectedPlayersList.Contains(playersWhell.GetCurrentChar().gameObject))
            {

                selectedPlayersList.Add(playersWhell.GetCurrentChar().gameObject);
                AddPlayerAtributes();

                charsPortrait[selectPos].sprite = playerAtributesList[selectPos].Portrait;
                tmpPortrait[selectPos].text = playerAtributesList[selectPos].PlayerName;
                portraitFrame[selectPos].gameObject.SetActive(true);
                //Restrições de canvas
                tmpCharName.color = Color.grey;
                bttSelectPlayer.interactable = false;
                //Gatilho do dado
                SelectCharVMCamera.Instance.SetDicePosition();
                bottonButtons.SetActive(false);
                playersWhell.GetDice().PrepareToRollDice();
            }
        }

      
    }
    public void Btt_UndoSelection()
    {

        foreach (Image portrait in portraitFrame) { portrait.gameObject.SetActive(false); }
        playerAtributesList.Clear();
        selectedPlayersList.Clear();
        selectPos = 0;

        bttSelectPlayer.interactable = true;
        bottonButtons.SetActive(true);
        img_CharName.gameObject.SetActive(true);
        confirmElements.SetActive(false);
    }
    public void Btt_Confirm()
    {

        FakeSaveSystem.SetPlayerAtributes(playerAtributesList);
        canLoadScene.LoadScene();
    }

    void GoToPlayerSelect()
    {
        playerAtributesList[selectPos].Initiative = playersWhell.GetDice().GetRollValue();
        tmpInitiative[selectPos].text = playerAtributesList[selectPos].Initiative.ToString();
        selectPos++;
        OrderTimeLine();
        SelectCharVMCamera.Instance.SetPlayerPosition();
        bottonButtons.SetActive(true);
        if (playerAtributesList.Count == FakeSaveSystem.NumberOfPlayers) { EnableConfirmElements(); }
    }
    void AddPlayerAtributes()
    {
        PlayerAtributes playerAtributes = new PlayerAtributes();
        playerAtributes.PlayerName = selectedPlayersList[selectPos].GetComponent<Player>().GetPlayerName();
        playerAtributes.Portrait = selectedPlayersList[selectPos].GetComponent<Player>().GetPortrait();
        playerAtributes.PlayerReference = selectedPlayersList[selectPos].GetComponent<Player>().GetPlayerReference();
        playerAtributesList.Add(playerAtributes);
    }
    void OrderTimeLine()
    {
        playerAtributesList = playerAtributesList.OrderByDescending(x => x.Initiative).ToList();
        for (int i = 0; i < selectedPlayersList.Count; i++)
        {
            tmpPortrait[i].text = playerAtributesList[i].PlayerName;
            tmpInitiative[i].text = playerAtributesList[i].Initiative.ToString();
            charsPortrait[i].sprite = playerAtributesList[i].Portrait;
        }
    }
    void EnableConfirmElements()
    {
        bottonButtons.SetActive(false);
        img_CharName.gameObject.SetActive(false);
        confirmElements.SetActive(true);
    }

}
