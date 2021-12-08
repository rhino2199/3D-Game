using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    public float BatteryTime;
    public RectTransform BatteryUI1;
    public RectTransform BatteryMask;
    public RectTransform BatteryUI2;
    public RectTransform BatteryMask2;
    public TextMeshProUGUI BatteryCounter;
    public int BatteriesFound = 0;
    //One Step on the Battery meter
    Vector3 One = new Vector3(0f, -2f, 0f);

    bool Battery2 = true;
    //The current battery's time in ms
    public float BatteryCurrentTime;
    //The current total battery life out of 30
    public float currentBattery;

    public FlashLightControl Flashlight;

    private void Awake()
    {
        BatteryCurrentTime = BatteryTime;
        currentBattery = BatteryTime;

    }

    public void BatteriesReset()
    {
        if(Battery2 &&  currentBattery != 30)
        {
            fillBatteries();
        } else if (!Battery2)
        {
            fillBatteries();
            fillBatteries();
        }
        BatteriesFound = 0;
        BatteryCounter.text = "Batteries Found: " + BatteriesFound + "/9";
    }

    private void Update()
    {
        if (Flashlight.FlashLightOn)
        {
            BatteryCurrentTime -= Time.deltaTime;
            if(BatteryCurrentTime < currentBattery)
            {
                currentBattery -= 1;
                if (Battery2)
                {
                    BatteryMask2.Translate(One);
                    BatteryUI2.Translate(-1 * One);
                }
                else
                {
                    BatteryMask.Translate(One);
                    BatteryUI1.Translate(-1 * One);
                }
            }

            
        }
        if(currentBattery == 0)
        {
           if (Battery2)
           {
               Battery2 = false;
               currentBattery = BatteryTime;
               BatteryCurrentTime = BatteryTime;
           } else
           {
              Flashlight.BatteriesDead();
           }
       }
    }

    public void fillBatteries()
    {
        Flashlight.FoundBattery();
        BatteriesFound += 1;
        BatteryCounter.text = "Batteries Found: " + BatteriesFound + "/9";
        float timeDif = BatteryTime - currentBattery;
        Vector3 move = -1 * timeDif * One;
        if (Battery2)
        {
            BatteryMask2.Translate(move);
            BatteryUI2.Translate(move * -1);
            currentBattery = BatteryTime;
            BatteryCurrentTime = BatteryTime;
        } else if (Flashlight.Dead)
        {
            BatteryMask.Translate(move);
            BatteryUI1.Translate(move* -1);
            currentBattery = BatteryTime;
            BatteryCurrentTime = BatteryTime;
        }
        else
        {
            BatteryMask.Translate(move);
            BatteryUI1.Translate(move * -1);
            move = currentBattery * One * -1;
            Battery2 = true;
            BatteryMask2.Translate(move);
            BatteryUI2.Translate(-1 * move);
        }
        Debug.Log(currentBattery + " " + Battery2);

    }

    public void emptyBatteries()
    {
        float oldBattery = currentBattery;
        if(currentBattery > 15)
        {
            currentBattery -= 15;
            BatteryCurrentTime -= 15.0f;
        }
        else
        {
            currentBattery = 0;
            BatteryCurrentTime = 0;
        }
        float timeDif = oldBattery - currentBattery;
        Vector3 move = timeDif * One;
        if (Battery2)
        {
            BatteryMask2.Translate(move);
            BatteryUI2.Translate(move * -1);
            if(currentBattery == 0)
            {
                Battery2 = false;
                currentBattery = BatteryTime;
                BatteryCurrentTime = BatteryTime;
            }
        }
        else
        {
            BatteryMask.Translate(move);
            BatteryUI1.Translate(move * -1);
            if(currentBattery == 0)
            {
                Flashlight.BatteriesDead();
            }
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collectible")
        {
            GameObject.Destroy(collision.gameObject);
            fillBatteries();
        }
    }
}
