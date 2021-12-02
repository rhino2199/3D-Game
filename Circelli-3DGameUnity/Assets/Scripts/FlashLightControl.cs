using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour
{

    public GameObject FlashLight;
    public GameObject FLOnImage;
    public GameObject FLOffImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(323))
        {
            FlashLight.SetActive(true); 
            FLOnImage.SetActive(true);
            FLOffImage.SetActive(false);
        } else
        {
            FlashLight.SetActive(false);
            FLOnImage.SetActive(false);
            FLOffImage.SetActive(true);
        }
    }
}
