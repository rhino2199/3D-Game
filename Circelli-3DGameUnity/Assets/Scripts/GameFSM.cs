using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFSM : MonoBehaviour
{
    public FSMStateType StartState = FSMStateType.Start;
    private StateInterface[] StatePool;
    private StateInterface CurrentState;


    private void Awake()
    {
        StatePool = GetComponents<StateInterface>();
    }

   
}
