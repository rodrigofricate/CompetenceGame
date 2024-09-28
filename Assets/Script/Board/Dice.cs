using Assets.Script.Enums;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
   
    Vector3 diceStartPosition;

    [SerializeField] Transform[] diceFaces;
    Rigidbody rb;
    [SerializeField] int rollValue = 0;

    [SerializeField] Material regularMatrial;
    [SerializeField] Material shinningMaterial;
    bool canRoll;

    public Action actionAfterRollDice = null;



    void Start()
    {
        diceStartPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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
                        StartCoroutine(RollDiceRoutine());
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
        transform.position = diceStartPosition;
    }



    //Publicos
    public int GetRollValue() { return rollValue; }
    public void PrepareToRollDice()
    {
        canRoll = true;
    }
    //Rotinas
    IEnumerator RollDiceRoutine()
    {
        canRoll = false;
        gameObject.GetComponent<MeshRenderer>().material = regularMatrial;

        AudioManager.instance.PlayFXAudio(EnumAudioClip.RollDice);

        Vector3 _force = new Vector3(0, Random.Range(80, 110), 0);
        Vector3 _torque = new Vector3(Random.Range(100, 1000), Random.Range(100, 1000), Random.Range(100, 1000));
        rb.AddForce(_force * Random.Range(6, 10));
        rb.AddTorque(_torque * Random.Range(20, 100));

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
        if(actionAfterRollDice != null) { actionAfterRollDice.Invoke(); }
        ResetDicePosition();
    }
}
