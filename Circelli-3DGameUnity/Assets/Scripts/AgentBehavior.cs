


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AgentBehavior : MonoBehaviour
{

    public Transform Destination = null;
    private NavMeshAgent ThisAgent = null;
    int currentPoint;
    public Transform[] Points = new Transform[3];


    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>(); //Get navmesh component 
        currentPoint = 0;
        Destination = Points[currentPoint];
    }

    public void nextDestination()
    {
        Destination = Points[currentPoint];
        currentPoint += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(ThisAgent.transform.position == Destination.position)
        {
            nextDestination();
        }
        Destination = Points[currentPoint % 3];
        ThisAgent.SetDestination(Destination.position); //set destination position 
        Debug.Log(currentPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<BatteryManager>().emptyBatteries();
        }
        Debug.Log("hit");
        if(other.tag == "Destination")
        {
            nextDestination();
        }
    }
}
