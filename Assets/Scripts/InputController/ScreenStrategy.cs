using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStrategy : MonoBehaviour, InputInteface {

    public InputCustomController input;
    public bool chooseTime = false;
    public ScreenAboutGroup aboutGroup;
    public GameObject starategyScreen;
    public GameObject aboutGroupScreen;
    public GameObject aboutGroupController;
    public GameObject selectorAboutGroup;
    public GameObject content;
    private Vector3 startPos;
    private Vector3 endPos = new Vector3(0, -2675, 0);
    private Coroutine coro;

    // Use this for initialization
    void Start ()
    {
        startPos = content.transform.localPosition;
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator pressBack()
    {
        aboutGroupScreen.gameObject.SetActive(true);
        aboutGroupController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(starategyScreen, aboutGroupScreen));
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        //menu.SetActive(false);
        input.rotationX = aboutGroup.lastRotations;
        selectorAboutGroup.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(aboutGroup.optionRus, aboutGroup.optionEng, aboutGroup.selectMainPos%2));
        content.transform.position = startPos;
        starategyScreen.gameObject.SetActive(false);
        aboutGroup.chooseTime = true;
        gameObject.SetActive(false);
        
    }

    public void Click()
    {
        chooseTime = false;
        if (coro != null)
        {
            StopCoroutine(coro);
        }
        StartCoroutine(pressBack());
    }

    public void Back()
    {
        
       
    }

    [ContextMenu("scroll")]
    public void startScroll()
    {
        coro = StartCoroutine(AnimationController.inst.scrollContentStrategy(startPos, endPos, content));
    }
}
