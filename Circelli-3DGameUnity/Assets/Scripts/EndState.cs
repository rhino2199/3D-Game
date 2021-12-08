using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour, StateInterface
{
    public FSMStateType StateName { get { return FSMStateType.End; } }
    public BatteryManager BatteryManager;
    public GameFSM GameManager;
    public GameObject GoodEnding;
    public GameObject BadEnding;
    public GameObject BackGround;
    public GameObject Thanks;

    private void Awake()
    {
        GoodEnding.SetActive(false);
        BadEnding.SetActive(false);
        BackGround.SetActive(false);
        Thanks.SetActive(false);
}

    public void OnEnter()
    {
        if(BatteryManager.BatteriesFound == 9)
        {
            GoodEnding.SetActive(true);
        }
        else
        {
            BadEnding.SetActive(true);
        }
        BackGround.SetActive(true);
        Invoke("ThanksEnd", 10);
    }

    void ThanksEnd()
    {
        GoodEnding.SetActive(false);
        BadEnding.SetActive(false);
        Thanks.SetActive(true);
        Invoke("ReturnToStart", 5);
    }

    void ReturnToStart()
    {
        Thanks.SetActive(false);
        GameManager.ChangeToStart();
    }


    public void OnExit()
    {
        GoodEnding.SetActive(false);
        BadEnding.SetActive(false);
        BackGround.SetActive(false);
        Thanks.SetActive(false);
    }
}
