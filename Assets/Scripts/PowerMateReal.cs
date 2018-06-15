using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMateReal : MonoBehaviour {

	public PowerMateButton btn;

	public InputCustomController iCC;
	// Use this for initialization
	void Start () {
		btn.onPress += onPressPrint;
		btn.onLongPress += onLongPressPrint;
		btn.onRotate += onRotatePrint;
	}
	
	private void onPressPrint()
	{
		Debug.Log("onPress");
		transform.Translate(0, 0.1f, 0);
	}

	private void onLongPressPrint()
	{
		Debug.Log("onLongPress");
		transform.Translate(0, -0.1f, 0);
	}

	private void onRotatePrint(float speed)
	{
		iCC.rotationX = speed;
		Debug.Log("onRotate " + speed);
		//transform.Translate(speed * 0.01f, 0.0f, 0);
	}
}
