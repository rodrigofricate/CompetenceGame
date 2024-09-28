using Assets.Script.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{

    [SerializeField] Transform cameraPosition;
    [SerializeField] Transform fixLookAtPosition;
    [SerializeField] Transform diceRenderPosition;
    Vector3 diceStartPosition;

    [SerializeField] Transform[] diceFaces;
    Rigidbody rb;
    [SerializeField] int rollValue = 0;

    [SerializeField] Material regularMatrial;
    [SerializeField] Material shinningMaterial;
    bool canRoll;
    // Start is called before the first frame update


    void Start()
    {
        diceStartPosition = diceRenderPosition.position;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
        if (canRoll)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Dice"))
                {
                    gameObject.GetComponent<MeshRenderer>().material = shinningMaterial;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        RollDice();
                    }
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material = regularMatrial;
                }

            }
        }

    }

    //privado
    void ResetDicePosition()
    {
        diceRenderPosition.position = diceStartPosition;
    }



    //Publicos
    public int GetRollValue() { return rollValue; }
    public Transform GetCameraPosition() { return cameraPosition; }
    public Transform GetLookAtCameraPosition() { return cameraPosition; }
    public void PrepareToRollDice()
    {
        canRoll = true;
        BoardCameraVM.Instance.SetCameraPosition(fixLookAtPosition.gameObject, cameraPosition);
    }
    public void RollDice()
    {
        StartCoroutine(RollDiceRoutine());
    }


    //Rotinas
    IEnumerator RollDiceRoutine()
    {
        canRoll = false;
        gameObject.GetComponent<MeshRenderer>().material = regularMatrial;

        AudioManager.instance.PlayFXAudio(EnumAudioClip.RollDice);

        Vector3 _force = new Vector3(0, Random.Range(80, 110), 0);
        Vector3 _torque = new Vector3(Random.Range(100, 1000), Random.Range(100, 1000), Random.Range(100, 1000));
        rb.AddForce(_force * Random.Range(5, 10));
        rb.AddTorque(_torque * Random.Range(5, 100));

        while (!rb.IsSleeping())
        {
            yield return null;
        }
        int _RollValue = 1;
        float yPos = diceFaces[0].position.y;

        for (int i = 1; i < diceFaces.Length; i++)
        {
            if (diceFaces[i].position.y > yPos)
            {
                yPos = diceFaces[i].position.y;
                _RollValue = i + 1;
            }
        }
        rollValue = _RollValue;
        ResetDicePosition();
        Board.Instance.GetCurrentPlayer().GetComponent<Player>().MovePlayer();
    }
    IEnumerator AutoRollDiceRoutine()
    {

        BoardCameraVM.Instance.SetCameraPosition(fixLookAtPosition.gameObject, cameraPosition);
        Vector3 _force = new Vector3(0, Random.Range(80, 110), 0);
        Vector3 _torque = new Vector3(Random.Range(100, 1000), Random.Range(100, 1000), Random.Range(100, 1000));
        rb.AddForce(_force * Random.Range(5, 10));
        rb.AddTorque(_torque * Random.Range(5, 100));

        while (!rb.IsSleeping())
        {
            yield return null;
        }
        int _RollValue = 1;
        float yPos = diceFaces[0].position.y;

        for (int i = 1; i < diceFaces.Length; i++)
        {
            if (diceFaces[i].position.y > yPos)
            {
                yPos = diceFaces[i].position.y;
                _RollValue = i + 1;
            }
        }
        rollValue = _RollValue;
        Board.Instance.GetCurrentPlayer().GetComponent<Player>().MovePlayer();
    }
}
