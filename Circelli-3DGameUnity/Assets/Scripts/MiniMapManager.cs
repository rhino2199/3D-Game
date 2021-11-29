using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    GameObject Player;
    Transform PlayerPos;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPos.position.y > )
    }
}
