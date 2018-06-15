using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLang : MonoBehaviour
{

    private List<GameObject> rus = new List<GameObject>();
    private List<GameObject> eng = new List<GameObject>();
    

	// Use this for initialization
	void Start () {
	    GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

        
	    GameObject obj;
	    for (int i = 0; i < objects.Length; i++)
	    {
	        obj = objects[i];
	        if (obj.name.Contains("_eng"))
	        {
                eng.Add(obj);
	            
	        }
	        else if(obj.name.Contains("_rus"))
	        {
                rus.Add(obj);
	            
	        }
	    }
        SelectRus();
    }

    public void SelectRus()
    {
        int i;
        for (i = 0; i < rus.Count; i++)
        {
            rus[i].gameObject.SetActive(true);
        }

        for (i = 0; i < eng.Count; i++)
        {
            eng[i].gameObject.SetActive(false);
        }
    }

    public void SelectEng()
    {
        int i;
        for (i = 0; i < rus.Count; i++)
        {
            rus[i].gameObject.SetActive(false);
        }

        for (i = 0; i < eng.Count; i++)
        {
            eng[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
