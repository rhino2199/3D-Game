using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MonoBehaviour, StateInterface
{
    // Start is called before the first frame update
    public FSMStateType StateName { get { return FSMStateType.Pause; } }
    public GameObject[] PauseUI;

    private void Awake()
    {
        foreach (GameObject obj in PauseUI)
        {
            obj.SetActive(false);
        }
    }

    public void OnEnter()
    {
        foreach (GameObject obj in PauseUI)
        {
            obj.SetActive(true);
        }
    }
    public void OnExit()
    {
        foreach (GameObject obj in PauseUI)
        {
            obj.SetActive(false);
        }
    }
}
