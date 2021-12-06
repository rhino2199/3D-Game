using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFSM : MonoBehaviour
{
    public FSMStateType StartState = FSMStateType.Start;
    private StateInterface[] StatePool;
    private StateInterface NoAction = new EmptyState();
    private StateInterface CurrentState;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState.StateName == FSMStateType.Play)
            {
                ChangeToPause();
            } 
            else 
            {
                Application.Quit();
            }
               
        } 
        
    }


    private void Awake()
    {
        CurrentState = NoAction;
        StatePool = GetComponents<StateInterface>();
    }

    private void Start()
    {
        TransitionToState(StartState);
    }

    public void ChangeToPlay()
    {
        TransitionToState(FSMStateType.Play);
    }

    public void ChangeToPause()
    {
        TransitionToState(FSMStateType.Pause);
    }

    public void ChangeToStart()
    {
        TransitionToState(FSMStateType.Start);
    }

    private void TransitionToState(FSMStateType StateName)
    {
        CurrentState.OnExit();
        CurrentState = GetState(StateName);
        CurrentState.OnEnter();

        Debug.Log("Transitioned to " + CurrentState.StateName);
    }

    StateInterface GetState(FSMStateType StateName)
    {
        //Is the statename given a valid option
        foreach (var state in StatePool)
        {
            if (state.StateName == StateName)
            {
                return state;
            }
        }
        return NoAction;
    }


}
