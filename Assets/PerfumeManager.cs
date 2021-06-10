using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfumeManager : MonoBehaviour
{
    public UdpSocket udpSocket;
    public GameObject perfumemanager;


   
    public int Eugenol = 1;
    public int Woodmystique;
    public int Cedarwood;
    public int petitgrain;


    public int[] PerfumeRatio = new int[4];
    // Start is called before the first frame update
    void Start()
    {

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
