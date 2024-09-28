using Assets.Script;
using Assets.Script.Enums;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [HideInInspector] public static Board Instance;

    [Tooltip("Debug Mode")]
    [SerializeField] bool IsDebug;

    CharModelsHolder charModelsHolder;
    [SerializeField] Dice dice;
    [SerializeField] CanBoardMannager canBoardMannager;
    [SerializeField] GameObject[] boardHouses;


    PlayerTurnManager turnManager;
    GameObject[] playersTimeLine;
    private void Awake()
    {
        charModelsHolder = GetComponent<CharModelsHolder>();
        SingletonCheckAndStantiete();
        if (IsDebug) { SimulatedFake(); }
        LoadCharacters();



        turnManager = new PlayerTurnManager(playersTimeLine);
    }

    private void Start()
    {
        dice.actionAfterRollDice = GetCurrentPlayer().GetComponent<Player>().MovePlayer;
    }


    //Métodos privados
    void SingletonCheckAndStantiete()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Have more then one script in scene!");
        }
    }
    //Métodos públicos
    public PlayerTurnManager GetPlayerTurnManager() { return turnManager; }
    public Dice GetDice() { return dice; }
    public GameObject[] GetBoardHouses() { return boardHouses; }
    public GameObject GetCurrentPlayer() { return turnManager.GetCurrentPlayer(); }
    public void PassTurn()
    {
        if (GetCurrentPlayer().GetComponent<Player>().GetBoardPosition() != boardHouses.Length - 1)
        {
            EndTurn();
            dice.actionAfterRollDice = GetCurrentPlayer().GetComponent<Player>().MovePlayer;
            StartTurn();
        }
        else
        {
            //Caso tenha ganho o personagem em questão não passa o turno, mas sim começa a comemorar!
            AudioManager.instance.PlayFXAudio(EnumAudioClip.CorrectAnsware);

            GetCurrentPlayer().GetComponent<Player>().StartWinnerAnimation();
            canBoardMannager.EnableCanEndGame();
        }
    }
    void EndTurn()
    {

        turnManager.AdvanceTimeLine();
        canBoardMannager.RefreshCanvasTimeLine(turnManager);


    }
    void StartTurn()
    {
        Player _Player = GetCurrentPlayer().GetComponent<Player>();
        BoardCameraVM.Instance.SetCameraPosition(_Player.gameObject, _Player.GetPlayerCameraPosition());

        EnumFloorType _FloorTypeOfPlayer = boardHouses[_Player.GetBoardPosition()].GetComponent<Floor>().GetFloorType();
        canBoardMannager.EnableQuestion(_FloorTypeOfPlayer);
    }


    void SimulatedFake()
    {
        List<PlayerAtributes> playersList = new List<PlayerAtributes>();
        /*
        PlayerAtributes _player0 = new PlayerAtributes();
        _player0.PlayerName = "AJ";
        _player0.Initiative = 5;
        _player0.PlayerReference = EnumPlayerReference.AJ;
        playersList.Add(_player0);*/
        //0
        PlayerAtributes _player0 = new PlayerAtributes();
        _player0.PlayerName = "Michelle";
        _player0.Initiative = 7;
        _player0.PlayerReference = EnumPlayerReference.Michelle;
        playersList.Add(_player0);
        //1
        PlayerAtributes _player1 = new PlayerAtributes();
        _player1.PlayerName = "Claire";
        _player1.Initiative = 5;
        _player1.PlayerReference = EnumPlayerReference.Claire;
        playersList.Add(_player1);
        //2
        PlayerAtributes _player2 = new PlayerAtributes();
        _player2.PlayerName = "Ty";
        _player2.Initiative = 6;
        _player2.PlayerReference = EnumPlayerReference.Ty;
        playersList.Add(_player2);
        //3
        PlayerAtributes _player3 = new PlayerAtributes();
        _player3.PlayerName = "Granny";
        _player3.Initiative = 4;
        _player3.PlayerReference = EnumPlayerReference.Granny;
        playersList.Add(_player3);
        //Fake
        FakeSaveSystem.SetPlayerAtributes(playersList);
    }
    void LoadCharacters()
    {
        playersTimeLine = new GameObject[FakeSaveSystem.NumberOfPlayers];
        for (int i = 0; i < FakeSaveSystem.NumberOfPlayers; i++)
        {
            EnumPlayerReference playerReference = FakeSaveSystem.PlayerAtributes[i].PlayerReference;
            Vector3 startPosition = boardHouses[0].GetComponent<Floor>().GetAdjustTargetPosition();
            playersTimeLine[i] = Instantiate(charModelsHolder.GetCharByReference(playerReference), startPosition, Quaternion.identity);
            playersTimeLine[i].transform.Rotate(0, 90, 0);
            playersTimeLine[i].GetComponent<Player>().SetInitiative(FakeSaveSystem.PlayerAtributes[i].Initiative);
            boardHouses[0].GetComponent<Floor>().AddHeldPosition();
        }
    }
}
