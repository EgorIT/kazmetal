using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwapTMP : MonoBehaviour
{

	public TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("k"))
		{
			text.fontMaterial = MaterialsController.inst.glow;
		}
		
		if (Input.GetKeyDown("l"))
		{
			text.fontMaterial = MaterialsController.inst.simple;
		}
	}
}
