using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StateInterface
{
    FSMStateType StateName { get; }

    void OnEnter();
    void OnExit();

    FSMStateType ShouldTransitionToState();
}

