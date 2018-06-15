using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float sensitivityX = 10F;
    float rotationX = 0F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
	    rotationX = ClampAngleX(rotationX, minimumX, maximumX);
	    if (rotationX < 0)
	    {
	        FocusEng();
	    }
	    else
	    {
	        FocusRus();
	    }
    }

    private static float ClampAngleX(float angle, float min, float max)
    {
        if (angle < min)
        {
            angle += 360F;
        }
        if (angle > max)
        {
            angle -= 360F;
        }
        return Mathf.Clamp(angle, min, max);
    }

    private void FocusEng()
    {

    }

    private void FocusRus()
    {

    }
}
