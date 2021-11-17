
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
