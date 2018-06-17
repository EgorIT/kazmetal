using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private float timeClicked = 0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0))
        {
            timeClicked = Time.time;
            
        }
        else if (Input.GetMouseButton(0) && Input.GetMouseButton(1) ||
                 Input.GetMouseButton(1) && Input.GetMouseButton(0))
        {
            if (Time.time - timeClicked > 4.0)
            {
                Restart();
            }
        }
    }


    [ContextMenu("restart")]
    private void Restart()
    {
        SceneManager.LoadScene("Art_Scene");
    }
}