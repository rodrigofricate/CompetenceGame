using Assets.Script;
using UnityEngine;

public class PlayersWhell : MonoBehaviour
{
    [SerializeField] GameObject emptyGameObject;
    [SerializeField][Tooltip("Coloque no sentido horário")] GameObject[] playerArray;
    [SerializeField] Transform centerOfWhell;
    [SerializeField] Transform charLookAtPoint;
    [SerializeField] Light spotLigth;
    [SerializeField] Dice dice;

    //Isto aqui acontece para cada coordenada ser pássada como valor e não refernete ao boneco!
    GameObject[] whellpositions;
    int whellPos = 0;
    int currentPlayerPos = 0;
    private void Awake()
    {
        whellpositions = new GameObject[playerArray.Length];
        for (int i = 0; i < playerArray.Length; i++)
        {
            whellpositions[i] = Instantiate(emptyGameObject);
            whellpositions[i].transform.position = playerArray[i].transform.position;
        }
    }

    void Update()
    {

        RfmPhysics.RotateToTarget(centerOfWhell, whellpositions[whellPos].transform, 0.15f);

        foreach (GameObject player in playerArray)
        {
            RfmPhysics.RotateToTarget(player.transform, charLookAtPoint, 0.2f);
        }

        SpotLigth();
    }





    //Métodos públicos
    public void RotareWhellToRigth()
    {
        whellPos++;
        if (whellPos >= whellpositions.Length)
        {
            whellPos = 0;
        }
        currentPlayerPos--;
        if (currentPlayerPos < 0)
        {
            currentPlayerPos = playerArray.Length - 1;
        }

      


    }

    public void RotareWhellToLeft()
    {
        whellPos--;
        if (whellPos < 0)
        {
            whellPos = whellpositions.Length - 1;
        }
        currentPlayerPos++;
        if (currentPlayerPos >= playerArray.Length)
        {
            currentPlayerPos = 0;
        }
    }

    public Player GetCurrentChar() { return playerArray[currentPlayerPos].GetComponent<Player>(); }
    public Light GetSpotligth() { return spotLigth; }
    public Dice GetDice() { return dice; }
    PlayerAtributes GetPlayerAtribute(Player player)
    {
        PlayerAtributes _playerAtributes = new PlayerAtributes();
        _playerAtributes.PlayerName = player.GetPlayerName();
        _playerAtributes.Portrait = player.GetPortrait();
        _playerAtributes.PlayerReference = player.GetPlayerReference();
        _playerAtributes.Initiative = 0;
        return _playerAtributes;


    }
    void SpotLigth()
    {
        PlayerAtributes _currentChar = GetPlayerAtribute(playerArray[currentPlayerPos].GetComponent<Player>());
        if (FakeSaveSystem.ContainPlayer(_currentChar))
        {
            spotLigth.gameObject.SetActive(false);
        }
        else
        {
            spotLigth.gameObject.SetActive(true);
        }
    }

}
