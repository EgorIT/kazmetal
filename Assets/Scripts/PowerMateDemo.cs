using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMateDemo : MonoBehaviour {
    public PowerMateButton btn;
    public InputCustomController inputCustomController;
	// Use this for initialization
	void Start () {
        btn.onPress += onPressPrint;
        btn.onLongPress += onLongPressPrint;
        btn.onRotate += onRotatePrint;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    [ContextMenu("click")]
    private void onPressPrint()
    {
        inputCustomController.Click();
    }
    [ContextMenu("back")]
    private void onLongPressPrint()
    {
        inputCustomController.Back();
    }
    [ContextMenu("rotate")]
    private void onRotatePrint(float speed)
    {
        inputCustomController.Rotate(speed);
    }
}
