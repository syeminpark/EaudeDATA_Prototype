using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{

    public Text TimeCount;
    public float TimeCost;
    public bool isTimeStart;
    public float Lastime;
    public float MaxTime=4;
    public bool isDecide=false;

    public PerfumeManager perfumemanager;
    public int petitgrain;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isTimeStart)
        {
            TimeCost -= Time.deltaTime;
            TimeCount.text = "진행된 시간" + TimeCost;
        }
        else
        {
            TimeCost = 0f;
        }

        if (isDecide==true)
        {
            if (TimeCost > MaxTime)
            {
                perfumemanager.petitgrain = 4;
}
            else
            {
                perfumemanager.petitgrain = 2;
            }

            isDecide = false;
        }
    }

    public void startSW()
    {
        isTimeStart = true;
    }

    public void stopSW()
    {
        isTimeStart = false;
        Lastime = TimeCost;
        
        isDecide = true;
    }
}
