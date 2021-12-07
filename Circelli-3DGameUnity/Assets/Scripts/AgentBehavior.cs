


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
    public float CollCool;


    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>(); //Get navmesh component 
        currentPoint = 0;
        Destination = Points[currentPoint];
        CollCool = 1.0f;
    }

    public void nextDestination()
    {
        currentPoint += 1;
        Destination = Points[currentPoint % Points.Length];
        Debug.Log(currentPoint);
    }

    // Update is called once per frame
    void Update()
    {
        ThisAgent.SetDestination(Destination.position); //set destination position 
        CollCool -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(CollCool <= 0)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<BatteryManager>().emptyBatteries();
                CollCool = 1.0f;

            }
            if (other.tag == "Destination")
            {
                nextDestination();
                Debug.Log("hit");
                CollCool = 1.0f;
            }
            
        }

        
    }
}
