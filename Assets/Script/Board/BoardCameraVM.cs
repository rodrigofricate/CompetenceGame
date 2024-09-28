using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BoardCameraVM : MonoBehaviour
{
    [HideInInspector] public static BoardCameraVM Instance;
    CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform diceCameraPosition;
    [SerializeField] Transform diceCameraLookAt;

    private void Awake()
    {
        SingletonCheckAndStantiete();
    }
    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        virtualCamera.LookAt = Board.Instance.GetCurrentPlayer().transform;
       virtualCamera.Follow = Board.Instance.GetCurrentPlayer().GetComponent<Player>().GetPlayerCameraPosition();
    }


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
    public void SetCameraPosition(GameObject target, Transform cameraPos)
    {
            virtualCamera.LookAt = target.transform;
            virtualCamera.Follow = cameraPos;
    }
    public void SetCameraToDicePosition()
    {
        virtualCamera.LookAt = diceCameraLookAt;
        virtualCamera.Follow = diceCameraPosition;
    }
}
