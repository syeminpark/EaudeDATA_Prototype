﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



[DataContract]
internal class SimpleReq
{
    [DataMember]
    public int state_FromUnity;
    
}



public class www_Req : MonoBehaviour
{
    private static readonly string host = "http://127.0.0.1:5000/test";
    //private static readonly string Unityhost = "http://127.0.0.1:5000/unity";

    //1. 변수 선언
    public int appState=0;
    public string pyHost;
    public string result;
    char sp = ',';
    public string[] resultArray;
    public bool isUnder = false;
    public bool isOver = false;
    public Text popup_Text;


    //2. 

    public void POST()
    {
        StartCoroutine(POSTStart());

  
    }
    public void GET()
    {
        StartCoroutine(GETStart());
    }

    private void Update()
    {
        bool isUnder = result.Contains("UNDER"); // yn = true
        bool isOver = result.Contains("OVER"); // yn2 = false
                                            // 

        if (isUnder){
            popup_Text.text = "UNDER";
        }
        if (isOver)
        {
            popup_Text.text = "OVER";
        }

    }

    public void init_bool()
    {
        isUnder = false;
        isOver = false;
    }

    public void Registration()
    {
        //StartCoroutine(RegistrationCoroutine(Unityhost));
    }

    IEnumerator POSTStart()
    {
        yield return RequestCommon(UnityWebRequest.kHttpVerbPOST);
        
    }

    IEnumerator GETStart()
    {
        yield return RequestCommon(UnityWebRequest.kHttpVerbGET);
    }
    


    IEnumerator RequestCommon(string method)
    {
        var body =
        ToJsonBinary(new SimpleReq() { state_FromUnity = appState }
        );

        
        var www = new UnityWebRequest(host);
        www.method = method;
        www.uploadHandler = new UploadHandlerRaw(body);
        www.uploadHandler.contentType = "application/json";
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();


        pyHost = www.downloadHandler.text;
        resultArray=pyHost.Split(sp);
        result=resultArray[resultArray.Length - 1];
        Debug.Log(result);

     
       
        Debug.Log(www.downloadHandler.text);
    }

    public static byte[] ToJsonBinary<T>(T data)
    {
        var stream1 = new MemoryStream();
        var ser = new DataContractJsonSerializer(typeof(T));
        ser.WriteObject(stream1, data);

        stream1.Position = 0;
        StreamReader sr = new StreamReader(stream1);
        var jsonBody = sr.ReadToEnd();

        byte[] byteArray = Encoding.UTF8.GetBytes(jsonBody);
        return byteArray;
    }


   
   





}