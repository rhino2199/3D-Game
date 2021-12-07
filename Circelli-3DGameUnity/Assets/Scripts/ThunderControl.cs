using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    public GameObject ThunderLight;
    public AudioSource ThunderSound;
    float FlashLength = 0.15f;
    float CurrentFlash;
    float TimeToNextStrike;


    private void Awake()
    {
        ThunderLight.SetActive(false);
        CurrentFlash = FlashLength;
        Thunder();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFlash -= Time.deltaTime;
        TimeToNextStrike -= Time.deltaTime;
        if(TimeToNextStrike <= 0)
        {
            Thunder();
        }

        if(CurrentFlash < 0)
        {
            ThunderEnd();
        }
       
    }

    void Thunder()
    {
        CurrentFlash = FlashLength;
        TimeToNextStrike = Random.Range(10, 30);
        ThunderLight.SetActive(true);
        ThunderSound.Play();
    }

    void ThunderEnd()
    {
        ThunderLight.SetActive(false);
    }
}
