using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour, StateInterface
{
    public FSMStateType StateName { get { return FSMStateType.Play; } }

    public GameObject Player;
    public GameObject[] PlayUI;
    public GameObject Enemies;
    

    private void Awake()
    {
        Player.SetActive(false);
        foreach (GameObject obj in PlayUI)
        {
            obj.SetActive(false);
        }
        Enemies.SetActive(false);
    }

    public void OnEnter()
    {
        Player.SetActive(true);
        foreach (GameObject obj in PlayUI)
        {
            obj.SetActive(true);
        }
        Enemies.SetActive(true);
    }
    public void OnExit()
    {
        Player.SetActive(false);
        foreach (GameObject obj in PlayUI)
        {
            obj.SetActive(false);
        }
        Enemies.SetActive(false);
    }
}
