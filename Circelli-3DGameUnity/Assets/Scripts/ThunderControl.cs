using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    public GameObject ThunderLight;
    public AudioSource ThunderSound;
    float FlashLength = 0.5f;
    float CurrentFlash;


    private void Awake()
    {
        ThunderLight.SetActive(false);
        CurrentFlash = FlashLength;
        InvokeRepeating("Thunder", 5, Random.Range(5, 15));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFlash -= Time.deltaTime;
        if(CurrentFlash < 0)
        {
            CurrentFlash = FlashLength;
            Thunder();
        }
    }

    void Thunder()
    {
        ThunderLight.SetActive(true);
        ThunderSound.Play();
    }

    void ThunderEnd()
    {
        ThunderLight.SetActive(false);
    }
}
