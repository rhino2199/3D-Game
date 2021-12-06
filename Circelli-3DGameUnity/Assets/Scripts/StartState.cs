using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : MonoBehaviour, StateInterface
{
    public FSMStateType StateName { get { return FSMStateType.Start; } }
    public GameObject[] StartUI;
    public GameObject[] CreditsUI;



    public void OnEnter()
    {
        foreach (GameObject obj in StartUI)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in CreditsUI)
        {
            obj.SetActive(false);
        }
    }

    public void Credits()
    {
        foreach (GameObject obj in StartUI)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in CreditsUI)
        {
            obj.SetActive(true);
        }
    }

    public void Back()
    {
        foreach (GameObject obj in StartUI)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in CreditsUI)
        {
            obj.SetActive(false);
        }
    }

    public void OnExit()
    {
        foreach (GameObject obj in StartUI)
        {
            obj.SetActive(false);
        }
    }
}
