using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{

    public Text TimeCount;
    public float TimeCost;
    public bool isTimeStart;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }

    public void startSW()
    {
        isTimeStart = true;
    }

    public void stopSW()
    {
        isTimeStart = false;
    }
}
