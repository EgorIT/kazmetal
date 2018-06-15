using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMover : MonoBehaviour
{

	public RectTransform bgCanvas;
	public RectTransform allCanvas;

	public GameObject particles;

	private Vector3 lastMousePosition=Vector3.zero;
	private Vector3 nowMousePosition=Vector3.zero;
	private Vector3 nowMousePositionRaw=Vector3.zero;
	private Vector3 startMousePosition=Vector3.zero;
	private bool move = false;
	private float bgy = 0;

	private double angle = 0;
	private string caption;

	private float sensitivity = 100;
	//private  float 
	void Update()
	{
		/*if (Input.GetAxis("Mouse ScrollWheel") != 0f ) // forward
		{
			angle += Input.GetAxis("Mouse ScrollWheel");
			Debug.Log(Input.GetAxis("Mouse ScrollWheel")+" "+angle);

			if (Math.Abs(angle) > .5)
			{
				
			}
			
			
		}*/
/*
		if (Input.GetKeyDown("left"))
		{
			caption = "Left";
		}
		
		if (Input.GetKeyDown("right"))
		{
			caption = "Right";
		}
		
		if (Input.GetKeyDown("space"))
		{
			caption = "Space";
		}*/

		//rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		
		if (Input.GetMouseButtonDown(0))
		{
			startMousePosition = new Vector3(0,Input.GetAxis("Mouse Y"))*sensitivity;
			move = true;
			//lastMousePosition=startMousePosition;
		}

		if (move)
		{
			Debug.Log(new Vector3(0,Input.GetAxis("Mouse Y"))*sensitivity);
			//nowMousePosition = lastMousePosition - new Vector3(0,Input.GetAxis("Mouse Y"))*sensitivity;
			//nowMousePosition-=nowMousePositionRaw -lastMousePosition;
			//Debug.Log(lastMousePosition.y);
			//Debug.Log(nowMousePosition.y);
			//Debug.Log(bgCanvas.anchoredPosition.y);
			//bgCanvas.anchoredPosition += new Vector2(0, -nowMousePosition.y/1.666f);
			bgCanvas.anchoredPosition += new Vector2(0, Input.GetAxis("Mouse Y")*sensitivity);
			allCanvas.anchoredPosition += new Vector2(0, Input.GetAxis("Mouse Y")*sensitivity);
			//allCanvas.anchoredPosition += new Vector2(0, -nowMousePosition.y/1.666f);
			//Debug.Log(bgCanvas.anchoredPosition.y);
			bgy = particles.transform.position.y - nowMousePosition.y;
			//particles.transform.position = new Vector3(-37.8f, particles.transform.position.y-nowMousePosition.y/25f,36.5f);
			particles.transform.position = new Vector3(0, Input.GetAxis("Mouse Y")*sensitivity,0);
			lastMousePosition =lastMousePosition- nowMousePosition;
		}
		if (Input.GetMouseButtonUp(0))
		{
			move = false;
		}
	}

	public void OnGUI()
	{
		//GUI.Label(new Rect(10, 10, 100, 20), angle.ToString(), new GUIStyle(){fontSize= 50});
		GUI.Label(new Rect(10, 10, 100, 20), caption, new GUIStyle(){fontSize= 50});
		
	}
}
