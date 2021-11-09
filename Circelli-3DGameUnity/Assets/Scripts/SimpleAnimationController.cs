using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider), typeof(Animator))]

public class SimpleAnimationController : MonoBehaviour
{

    public BoxCollider ThisCollider;
    public string PlayerTag = "Player";
    public string BoolName = "IsOpen";
    public Animator ThisAnimator;

    private void Awake()
    {
        ThisCollider = GetComponent<BoxCollider>();
        ThisAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PlayerTag)
        {
            ThisAnimator.SetBool(BoolName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == PlayerTag)
        {
            ThisAnimator.SetBool(BoolName, false);
        }
    }


}
