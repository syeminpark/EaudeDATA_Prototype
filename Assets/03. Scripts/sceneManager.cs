using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public bool isAnimEnd;
    // Start is called before the first frame update
    void Start()
    {
        isAnimEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }


        if (isAnimEnd)
            NextScene();
    }

    public void NextScene()
    {

        SceneManager.LoadScene(1);
    }
}
