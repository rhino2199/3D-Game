using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour
{

    public GameObject FlashLight;
    public GameObject FLOnImage;
    public GameObject FLOffImage;
    bool FlashLightOn;

    private void Awake()
    {
        FlashLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLightOn = !FlashLightOn;
            Flashlight();
        }
    }

    void Flashlight()
    {

        if(FlashLightOn)
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
