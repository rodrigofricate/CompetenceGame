using Assets.Script.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] Transform destinationCoordinate;
    [SerializeField] Transform[] waitCoordinates;
    [SerializeField] int heldPositions = 0;
    [SerializeField] EnumFloorType floorType;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public EnumFloorType GetFloorType() {  return floorType; }
    public void AddHeldPosition() { heldPositions++; }
    public void RemoveHeldPosition() { heldPositions = (heldPositions > 0) ? heldPositions - 1 : heldPositions; }
    public Vector3 GetAdjustTargetPosition() { return waitCoordinates[heldPositions].transform.position; }


}
