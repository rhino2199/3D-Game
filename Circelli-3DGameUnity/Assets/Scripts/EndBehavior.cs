using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Animator))]


public class EndBehavior : MonoBehaviour
{
    public BoxCollider ThisCollider;
    public string PlayerTag = "Player";
    public string BoolName = "IsOpen";
    public Animator ThisAnimator;
    public GameFSM GameManager;

    private void Awake()
    {
        ThisCollider = GetComponent<BoxCollider>();
        ThisAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PlayerTag)
        {
            ThisAnimator.SetBool(BoolName, true);
            Invoke("End", 3);
        }
    }

    void End()
    {
        GameManager.ChangeToEnd();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == PlayerTag)
        {
            ThisAnimator.SetBool(BoolName, false);
        }
    }

}
