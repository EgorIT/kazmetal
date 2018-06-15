using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StasAnim : MonoBehaviour
{

    public List<Image> images; 
    private List<int> colorsInts = new List<int>();
    private int firstIndex = 0;
    private int lastindex = 2;
    private bool rost = true;
   

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < 12; i++)
	    {
            colorsInts.Add(0);
	    }
	    colorsInts[0] = 1;
	    colorsInts[1] = 1;
	    colorsInts[2] = 1;

	    StartCoroutine(Anim());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetColors(List<int> colors)
    {
        for (int i = 0; i < 12; i++)
        {
            images[i].color = colors[i]==0 ? Color.white: Color.green;
        }
    }

    private bool CountSolid(List<int> colors)
    {
        int count = 0;
        for (int i = 0; i < 12; i++)
        {
            if (colors[i] == 1)
            {
                count++;
            }
        }

        if (rost)
        {
            if (count == 9)
            {
                rost = false;
            }
        }
        else
        {
            if (count == 3)
            {
                rost = true;
            }
        }

        return rost;
    }

    private IEnumerator Anim()
    {
        while (true)
        {
            SetColors(colorsInts);
            Step();
            yield return new WaitForSeconds(1f);
        }
    }

    private void Step()
    {
        if (CountSolid(colorsInts))
        {
            firstIndex -= 2;
            lastindex -= 1;
        }
        else
        {
            firstIndex -= 1;
            lastindex -= 2;
        }

        if (firstIndex < 0)
        {
            firstIndex += 12;
        }
        if (lastindex < 0)
        {
            lastindex += 12;
        }

        for (int i = 0; i < 12; i++)
        {
            if (firstIndex < lastindex)
            {
                if (i > firstIndex && i < lastindex)
                {
                    colorsInts[i] = 1;
                }
                else
                {
                    colorsInts[i] = 0;
                }
            }
            else
            {
                if (i > firstIndex || i < lastindex)
                {
                    colorsInts[i] = 1;
                }
                else
                {
                    colorsInts[i] = 0;
                }

            }
        }

        colorsInts[firstIndex] = 1;
        colorsInts[lastindex] = 1;
    }


    

    
}
