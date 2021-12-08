using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : MonoBehaviour, StateInterface
{
    public FSMStateType StateName { get { return FSMStateType.Start; } }
    public GameObject[] StartUI;
    public GameObject[] CreditsUI;
    public GameObject[] StartStory;
    GameObject[] Batteries;
    public GameObject Player;
    public BatteryManager BatteryManager;


    private void Awake()
    {
        Batteries = GameObject.FindGameObjectsWithTag("Collectible");

    }

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

        foreach (GameObject obj in StartStory)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in Batteries)
        {
            obj.SetActive(true);
        }
        Player.SetActive(true);
        Player.GetComponent<Transform>().position = new Vector3(0, 0, -8);
        Player.GetComponent<Transform>().rotation = new Quaternion();
        Player.SetActive(false);
        BatteryManager.BatteriesReset(); 
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

    private void First()
    {
        StartStory[0].SetActive(false);
        StartStory[1].SetActive(true);
    }

    private void Second()
    {
        StartStory[1].SetActive(false);
        StartStory[2].SetActive(true);
    }

    private void Last()
    {
        StartStory[2].SetActive(false);
    }

    public void OnExit()
    {
        foreach (GameObject obj in StartUI)
        {
            obj.SetActive(false);
        }

        StartStory[0].SetActive(true);
        Invoke("First", 5);
        Invoke("Second", 10);
        Invoke("Last", 15);
    }
}
