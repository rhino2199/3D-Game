using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour
{

    public GameObject FlashLight;
    public GameObject FLOnImage;
    public GameObject FLOffImage;
    public bool FlashLightOn;
    public bool Dead;

    private void Awake()
    {
        FlashLightOn = true;
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FlashLightOn = !FlashLightOn;
                Flashlight();
            }
        }
        
    }

    public void BatteriesDead()
    {
        Dead = true;
        if (FlashLightOn)
        {
            FlashLightOn = false;
            Flashlight();
        }
    }

    public void FoundBattery()
    {
        Dead = false;
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
