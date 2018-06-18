using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("test")]
    public void test()
    {
        List<LehaLoh> list =new List<LehaLoh>();
        list.Add(new LehaLoh(true, "Стопудово лошара"));
        list.Add(new LehaLoh(list[0].isLoh, list[0].lehaloh));
        list[0].isLoh = false;
        Debug.Log(list[1].isLoh);
    }

    public class LehaLoh
    {
        public bool isLoh;
        public String lehaloh;

        public LehaLoh(bool isLoh, string lehaloh)
        {
            this.isLoh = isLoh;
            this.lehaloh = lehaloh;
        }

        public LehaLoh()
        {
            
        }
    }

}
