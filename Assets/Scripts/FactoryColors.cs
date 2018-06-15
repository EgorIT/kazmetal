using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryColors : MonoBehaviour
{

	public Scaler scaler;
	public Image factory;
	public float factoryTransparencyMax = 1;
	public float factoryTransparencyMin =0;
	public Image select;
	public float selectTransparencyMax=1;
	public float selectTransparencyMin=123/255f;
	public Text factoryName;
	public float factoryNameTransparencyMax = 1;
	public float factoryNameTransparencyMin= 107/255f;
	public float time=1;

	
	public void FadeOutFull()
	{
		StartCoroutine(FadeOutFullCoroutine());
	}

	private IEnumerator FadeOutFullCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(0, factoryTransparencyMax, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(0, selectTransparencyMax, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(0, factoryNameTransparencyMax, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, 0);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, 0);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, 0);
		yield return null;
	}
	
	
	public void FadeOut()
	{
		scaler.Off();
		StartCoroutine(FadeOutCoroutine());
	}

	private IEnumerator FadeOutCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(0, factoryTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(0, selectTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(0, factoryNameTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, 0);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, 0);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, 0);
		yield return null;
	}
	
	public void FadeIn()
	{
		scaler.On();
		StartCoroutine(FadeInCoroutine());
	}

	private IEnumerator FadeInCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(factoryTransparencyMin, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(selectTransparencyMin, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(factoryNameTransparencyMin, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, factoryTransparencyMin);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, selectTransparencyMin);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, factoryNameTransparencyMin);
		yield return null;
	}


	public void FadeInFull()
	{
		StartCoroutine(FadeInFullCoroutine());
	}

	private IEnumerator FadeInFullCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(factoryTransparencyMax, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(selectTransparencyMax, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(factoryNameTransparencyMax, 0, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, factoryTransparencyMax);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, selectTransparencyMax);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, factoryNameTransparencyMax);
		yield return null;
	}

	public void On()
	{
		StartCoroutine(OnCoroutine());
	}

	private IEnumerator OnCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(factoryTransparencyMax, factoryTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(selectTransparencyMax, selectTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(factoryNameTransparencyMax, factoryNameTransparencyMin, Mathf.SmoothStep(0, 1, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, factoryTransparencyMax);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, selectTransparencyMax);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, factoryNameTransparencyMax);
		yield return null;
	}

	public void Off()
	{
		StartCoroutine(OffCoroutine());
	}

    public void OffFast()
    {
        factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, factoryTransparencyMin);
        select.color = new Color(factory.color.r, factory.color.g, factory.color.b, selectTransparencyMin);
        factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, factoryNameTransparencyMin);
    }

	public IEnumerator OffCoroutine()
	{
		float inAnimationTime = time;

		while (inAnimationTime>0)
		{
			factory.color = new Color(factory.color.r,factory.color.g, factory.color.b, Mathf.Lerp(factoryTransparencyMax, factoryTransparencyMin, Mathf.SmoothStep(1, 0, inAnimationTime/time)));
			select.color = new Color(select.color.r,select.color.g, select.color.b, Mathf.Lerp(selectTransparencyMax, selectTransparencyMin, Mathf.SmoothStep(1, 0, inAnimationTime/time)));
			factoryName.color = new Color(factoryName.color.r,factoryName.color.g, factoryName.color.b, Mathf.Lerp(factoryNameTransparencyMax, factoryNameTransparencyMin, Mathf.SmoothStep(1, 0, inAnimationTime/time)));
			//Debug.Log(Mathf.SmoothStep(0, 1, inAnimationTime/time)+" "+inAnimationTime);
			inAnimationTime -= Time.deltaTime;
			yield return null;
		}
		factory.color = new Color(factory.color.r, factory.color.g, factory.color.b, factoryTransparencyMin);
		select.color = new Color(factory.color.r, factory.color.g, factory.color.b, selectTransparencyMin);
		factoryName.color = new Color(factoryName.color.r, factoryName.color.g, factoryName.color.b, factoryNameTransparencyMin);
		yield return null;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown("a")){
			On();
		}
		
		if (Input.GetKeyDown("s")){
			Off();
		}*/
	
	}
}
