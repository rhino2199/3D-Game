
/*
 * Author: Ryan Circelli
 * Date Created: 10-25-2021
 * Date Modified: 10-25-2021
 * Description: Behaviors for the minimap camera, including following the camera
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform Player;
    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }

    void Update()
    {
        if (Player.position.y < 1)
        {
            Floor1.SetActive(true);
            Floor2.SetActive(false);
            Floor3.SetActive(false);
            Floor4.SetActive(false);
        }
        else if (Player.position.y > 1 && Player.position.y < 5)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(true);
            Floor3.SetActive(false);
            Floor4.SetActive(false);
        }
        else if (Player.position.y > 5 && Player.position.y < 9)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(false);
            Floor3.SetActive(true);
            Floor4.SetActive(false);
        }
        else if (Player.position.y > 9)
        {
            Floor1.SetActive(false);
            Floor2.SetActive(false);
            Floor3.SetActive(false);
            Floor4.SetActive(true);
        }
    }
}
