using Assets.Script.Enums;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navAgent;
    Animator anim;
    [SerializeField] string playerName;
    [SerializeField] EnumPlayerReference playerReference;
    int boardPosition = 0;
    int movePoints = 0;
    [SerializeField] int initiative = 0;
    [SerializeField] Transform playerCameraPosition;
    [SerializeField] Sprite portrait;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }




    public void MovePlayer()
    {
        StartCoroutine(Move());
    }
    public void WrongQuestion()
    {
        StartCoroutine(WrongQuestionRoutine());
    }
    public void StartWinnerAnimation() { anim.SetBool("Win", true); }
    public void EndWinnerAnimation() { anim.SetBool("Win", false); }


    public int GetBoardPosition() { return boardPosition; }
    public int GetInitiative() { return initiative; }
    public void SetInitiative(int initiative) { this.initiative = initiative; }
    public void SetPlayerName(string name) { playerName = name; }
    public string GetPlayerName() { return playerName; }
    public EnumPlayerReference GetPlayerReference() { return playerReference; }
    public Sprite GetPortrait() { return portrait; }
    public Transform GetPlayerCameraPosition() { return playerCameraPosition; }

    //Rotinas
    IEnumerator Move()
    {
        BoardCameraVM.Instance.SetCameraPosition(gameObject, playerCameraPosition);
        movePoints = Board.Instance.GetDice().GetRollValue();
        VacateBoardPosition();

        AudioManager.instance.PlayFootStepsFX();

        while (movePoints > 0)
        {
            if (boardPosition < Board.Instance.GetBoardHouses().Length - 1)
            {
                anim.SetBool("Walk", true);
                Vector3 destinations = Board.Instance.GetBoardHouses()[boardPosition + 1].transform.position;
                navAgent.SetDestination(destinations);
                if (Vector3.Distance(transform.position, destinations) <= 0.2f)
                {
                    movePoints--;
                    boardPosition++;
                }
            }
            else
            {
                movePoints = 0;
            }
            yield return null;
        }

        StartCoroutine(AdjustPosition());
    }
    IEnumerator AdjustPosition()
    {
        float y = transform.rotation.eulerAngles.y;
        Vector3 targetAdjustPos = Board.Instance.GetBoardHouses()[boardPosition].GetComponent<Floor>().GetAdjustTargetPosition();
        while (Vector3.Distance(transform.position, targetAdjustPos) >= 0.2f)
        {
            navAgent.SetDestination(targetAdjustPos);
            yield return null;
        }
        navAgent.SetDestination(transform.position);
        anim.SetBool("Walk", false);

        float rotSpeed = -100;
        if (transform.rotation.eulerAngles.y < y) { rotSpeed = rotSpeed * -1; }

        while (Mathf.Abs(transform.rotation.eulerAngles.y - y) > 1)
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
            yield return null;
        }

        AudioManager.instance.StopFootStepsFX();

        yield return new WaitForSeconds(1);
        //Pass
        Board.Instance.GetBoardHouses()[boardPosition].GetComponent<Floor>().AddHeldPosition();
        Board.Instance.PassTurn();
    }
    IEnumerator WrongQuestionRoutine()
    {
        anim.SetTrigger("Defeat");
        yield return new WaitForSeconds(2f);
        Board.Instance.PassTurn();
    }

    //[*********Métodos privados*********]
    void VacateBoardPosition()
    {
        if (boardPosition < Board.Instance.GetBoardHouses().Length)
        {
            Board.Instance.GetBoardHouses()[boardPosition].GetComponent<Floor>().RemoveHeldPosition();
        }
    }


}
