using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOtvet : MonoBehaviour, InputInteface {

    public bool chooseTime = false;
    public ScreenAboutGroup aboutGroup;
    public GameObject otvetScreen;
    public GameObject aboutGroupScreen;
    public GameObject aboutGroupController;
    public GameObject selectorAboutGroup;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator pressBack()
    {
        aboutGroupScreen.gameObject.SetActive(true);
        aboutGroupController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(otvetScreen, aboutGroupScreen));
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        //menu.SetActive(false);
        selectorAboutGroup.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(aboutGroup.optionRus, aboutGroup.optionEng, aboutGroup.selectMainPos));
        otvetScreen.gameObject.SetActive(false);
        aboutGroup.chooseTime = true;
        gameObject.SetActive(false);

    }

    public void Click()
    {
        
    }

    public void Back()
    {
        chooseTime = false;
        StartCoroutine(pressBack());
    }
}
