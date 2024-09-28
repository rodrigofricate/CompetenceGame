using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelectCharVMCamera : MonoBehaviour
{
    [HideInInspector] public static SelectCharVMCamera Instance;
    [SerializeField] Transform camSelectPlayerPos;
    [SerializeField] Transform camSelectPlayerLookAt;

    [SerializeField] Transform camDicePos;
    [SerializeField] Transform camDiceLookAt;

    [SerializeField] Light spotLigth;
    CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        SingletonCheckAndStantiete();
    }
    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        spotLigth.gameObject.SetActive(false);
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

    public void SetPlayerPosition()
    {
        spotLigth.gameObject.SetActive(false);

        virtualCamera.Follow = camSelectPlayerPos; ;
        virtualCamera.LookAt = camSelectPlayerLookAt;
       
    }
    public void SetDicePosition()
    {
        spotLigth.gameObject.SetActive(true);

        virtualCamera.Follow = camDicePos; ;
        virtualCamera.LookAt = camDiceLookAt;
    }
}
