using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    GameObject Player;
    Transform PlayerPos;
    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPos.position.y < 1)
        {
            Floor1.SetActive(true);
            Floor2.SetActive(false);
            Floor3.SetActive(false);
            Floor4.SetActive(false);
        } else if(PlayerPos.position.y > 1 && PlayerPos.position.y < 5)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(true);
            Floor3.SetActive(false);
            Floor4.SetActive(false);
        }
        else if (PlayerPos.position.y > 5 && PlayerPos.position.y < 9)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(false);
            Floor3.SetActive(true);
            Floor4.SetActive(false);
        }
        else if (PlayerPos.position.y > 9)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(false);
            Floor3.SetActive(false);
            Floor4.SetActive(true);
        }
    }
}
