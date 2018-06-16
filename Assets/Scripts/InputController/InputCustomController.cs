using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCustomController : MonoBehaviour {

    public float sensitivityX = 5F;
    public float rotationX = 0F;
    public float minimumX = -60F;
    public float maximumX = 60F;
    
    public Color32 selectedColor = new Color32(255, 155, 0, 255);
    public Color32 unselectedColor = new Color32(26, 110, 157, 255);

    public List<MonoBehaviour> listClick; 
    public List<MonoBehaviour> listBack; 
    

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("q"))
	    {
	        RotateBack();
	    }
	    
	    if (Input.GetKeyDown("w"))
	    {
	        Rotate();
	    }
	    
	    if (Input.GetKeyDown("e"))
	    {
	        Back();
	    }
	    
	    if (Input.GetKeyDown("r"))
	    {
	        Click();
	    }
	    //rotationX += Input.GetAxis("Mouse X") * sensitivityX;
	    //rotationX = ClampAngleX(rotationX, minimumX, maximumX);
	}

    private static float ClampAngleX(float angle, float min, float max)
    {
        if (angle < min)
        {
            angle += 120F;
        }
        
        if (angle > max)
        {
            angle -= 120F;
        }

        return angle;
    }

    
    //public void Rotate(float angle)
    [ContextMenu("rotate")]
    public void Rotate()
    {
        rotationX += 10f;
        rotationX = ClampAngleX(rotationX, minimumX, maximumX);
    }
    
    [ContextMenu("rotate_back")]
    public void RotateBack()
    {
        rotationX -= 10f;
        rotationX = ClampAngleX(rotationX, minimumX, maximumX);
    }
    
    [ContextMenu("click")]
    public void Click()
    {
        for (int i = 0; i < listClick.Count; i++)
        {
            if (listClick[i].isActiveAndEnabled)
            {
                InputInteface inputInteface = listClick[i].GetComponent<InputInteface>();
                if (inputInteface != null)
                {
                    inputInteface.Click();
                }
            }
        }
    }

    [ContextMenu("back")]
    public void Back()
    {
        for (int i = 0; i < listBack.Count; i++)
        {
            if (listBack[i].isActiveAndEnabled)
            {
                InputInteface inputInteface = listBack[i].GetComponent<InputInteface>();
                if (inputInteface != null)
                {
                    inputInteface.Back();
                }
            }
        }
    }


}
