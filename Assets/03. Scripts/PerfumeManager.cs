using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfumeManager : MonoBehaviour
{
    public UdpSocket_PCB udpSocket;
    public GameObject perfumemanager;


    string tempStr = "Sent from PCB xxxx";
    public int Eugenol = 1;
    public int Woodmystique;
    public int Cedarwood;
    public int petitgrain;

    public int StartInt;


    public int[] PerfumeRatio = new int[4];
    // Start is called before the first frame update
    void Start()
    {

    }


    // 0이 진행상태, 1최종비ㅇ


    public void SendToPCB()
    {
        string send_data = "#PC_LINK"+StartInt+Eugenol+","+Woodmystique + "," + Cedarwood + "," + petitgrain + ",".ToString();
        udpSocket.SendData(send_data);
        print(send_data);
  
    }
    
    

    private void Update()
    {
        PerfumeRatio[0] = Eugenol;
        PerfumeRatio[1] = Woodmystique;
        PerfumeRatio[2] = Cedarwood;
        PerfumeRatio[3] = petitgrain;

        
    }




    public void GetData()
    {
       
        DontDestroyOnLoad(perfumemanager);
        SceneManager.LoadScene(2);
        
    }


}
