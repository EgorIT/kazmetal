using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class forfor : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        Debug.Log("start");
	    int k = 0;
	    for (int i = 0; i < 2147483647; i++)
	    {
	        //for (int j = 0; j < 2147483647; j++)
	        //{
	            k = 1;
	        //}
	    }
        Debug.Log("finish");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
