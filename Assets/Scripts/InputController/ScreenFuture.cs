using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFuture : MonoBehaviour, InputInteface
{
	public InputCustomController input;
    private bool isSlide = true;
    public List<GameObject> images = new List<GameObject>();
    private int currentSlide = 0;
    private int nextSlide;
	public bool chooseTime = false;
	public MenuMain menuMain;
	private Coroutine coro;
	public GameObject mainMenuScreen, selectorMainMenu, futureScreen, mainMenuController;
	public GameObject menu;
	public int selectMainPos = 0;
	private int newPos;

	public float slideTime;
	// Use this for initialization
	void Start ()
	{
	    //StartCoroutine(SlideImage());
	}
	
	// Update is called once per frame
	void Update () {
		if (chooseTime)
		{
			GetFocus(input.rotationX + 59f);
		}
	}

	public void GetFocus(float value)
	{
		newPos = (int) (value / 30);
		if (selectMainPos != newPos)
		{
            
			chooseTime = false;
			if ((newPos == selectMainPos+1))
			{
                
				StartCoroutine(SlideImage());
			}
		    if ((newPos==0&&selectMainPos==images.Count-1))
			{
                
				StartCoroutine(SlideImage());
			}
			if ((newPos == selectMainPos-1))
			{
			    
                StartCoroutine(SlideImageBack());
			}
		    if ((newPos==images.Count-1&&selectMainPos==0))
			{
			    
                StartCoroutine(SlideImageBack());
			}
			selectMainPos = newPos;
       
		}
	}

	public IEnumerator SlideImage()
    {
       //while (isSlide)
       //{
       //    yield return new WaitForSeconds(slideTime);
            nextSlide = currentSlide + 1 == images.Count ? 0 : currentSlide + 1;
            yield return StartCoroutine(
                AnimationController.inst.changeScreenBack(images[currentSlide], images[nextSlide]));
            currentSlide = nextSlide;
	    chooseTime = true;
        //}
    }
	public IEnumerator SlideImageBack()
    {
       //while (isSlide)
       //{
       //    yield return new WaitForSeconds(slideTime);
            nextSlide = currentSlide - 1 == -1 ? images.Count-1 : currentSlide - 1;
            yield return StartCoroutine(
                AnimationController.inst.changeScreenBack(images[currentSlide], images[nextSlide]));
            currentSlide = nextSlide;
	    chooseTime = true;
        //}
    }

	public void Click()
	{
		
	}

	public void Back()
	{
		if (chooseTime)
		{
		    chooseTime = false;
			StartCoroutine(pressBack());
		}
	}
	
	private IEnumerator pressBack()
	{
		mainMenuScreen.gameObject.SetActive(true);
		mainMenuController.gameObject.SetActive(true);
		StartCoroutine(AnimationController.inst.changeScreenBack(futureScreen, mainMenuScreen));
		//yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
		//menu.SetActive(false);
	    input.rotationX = menuMain.lastRotations;
		selectorMainMenu.SetActive(true);
		yield return StartCoroutine(
			AnimationController.inst.changeMenuShowIn22(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
		gameObject.SetActive(false);
		menuMain.chooseTime = true;
		gameObject.SetActive(false);
		coro = null;
	}
}
