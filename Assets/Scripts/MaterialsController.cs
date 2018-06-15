using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsController : MonoBehaviour
{

	public Material glow;
	public Material simple;

	public static MaterialsController inst;
	// Use this for initialization
	void Start ()
	{
		inst = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
