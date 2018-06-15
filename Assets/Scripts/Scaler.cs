using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Scaler : MonoBehaviour
{

	public RectTransform rect;
	public float time;
	
	public void On()
	{
		rect.gameObject.SetActive(true);
		StartCoroutine(OnCoroutine());
	}

	private IEnumerator OnCoroutine()
	{
		float size=0;
		float inAnimationTime = time;

		rect.localScale = Vector3.zero;
		while (inAnimationTime>0)
		{
			size = Mathf.Lerp(0, 1, Mathf.SmoothStep(1, 0, inAnimationTime / time));
			rect.localScale = new Vector3(size,size,1);
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		rect.localScale = Vector3.one;
		yield return null;
	}

	public void Off()
	{
		StartCoroutine(OffCoroutine());
	}

	private IEnumerator OffCoroutine()
	{
		float size=0;
		float inAnimationTime = time;

		rect.localScale = Vector3.one;
		while (inAnimationTime>0)
		{
			size = Mathf.Lerp(1, 0, Mathf.SmoothStep(1, 0, inAnimationTime / time));
			rect.localScale = new Vector3(size,size,1);
			
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		rect.localScale = Vector3.zero;
		rect.gameObject.SetActive(false);
	}

	public void Update()
	{
		if (Input.GetKeyDown("n"))
		{
			On();
		}
		
		if (Input.GetKeyDown("b"))
		{
			Off();
		}
	}
}
