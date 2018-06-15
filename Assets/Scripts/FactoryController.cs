using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryController : MonoBehaviour
{

	public FactoryColors[] factoryColors;
	public FactoryColors activeNow;
	public Image map;

	//public Image factory;
	public float mapTransparencyMax = 1;
	public float mapTransparencyMin =0;
	public float time=1;

	public void Update()
	{
		if (Input.GetKeyDown("c"))
		{
			FadeIn();
		}

		if (Input.GetKeyDown("v"))
		{
			FadeOut();
		}
	}

	public void FadeIn()
	{
		StartCoroutine(FadeInCoroutine());
		factoryColors[0].gameObject.SetActive(true);
		factoryColors[0].FadeInFull();
		for (int i = 1; i < factoryColors.Length; i++)
		{
			factoryColors[i].gameObject.SetActive(true);
			factoryColors[i].FadeIn();
		}
		//activeNow.Off();	
	}
	
	private IEnumerator FadeInCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			map.color = new Color(map.color.r,map.color.g, map.color.b, Mathf.Lerp(mapTransparencyMax, mapTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		map.color = new Color(map.color.r, map.color.g, map.color.b, mapTransparencyMax);
		yield return null;
	}
	
	
	public void FadeOut()
	{
		StartCoroutine(FadeOutCoroutine());
		factoryColors[0].FadeOutFull();
		for (int i = 1; i < factoryColors.Length; i++)
		{
			factoryColors[i].FadeOut();
		}
		//activeNow.Off();	
	}
	
	private IEnumerator FadeOutCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			map.color = new Color(map.color.r,map.color.g, map.color.b, Mathf.Lerp( mapTransparencyMin, mapTransparencyMax, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		map.color = new Color(map.color.r, map.color.g, map.color.b, mapTransparencyMin);
		yield return null;
	}
	
}
