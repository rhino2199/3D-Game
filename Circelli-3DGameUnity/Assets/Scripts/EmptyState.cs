using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : StateInterface
{
    public FSMStateType StateName { get { return FSMStateType.Empty; } }

    public void OnEnter()
    {

    }
    public void OnExit()
    {

    }
}
