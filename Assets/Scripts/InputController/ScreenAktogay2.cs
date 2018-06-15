using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAktogay2 : MonoBehaviour, InputInteface
{


    public InputCustomController input;
    public GameObject mainMenuScreen, selectorMainMenu, aktogay2Screen, mainMenuController;
	public GameObject menu;
    //public List<Text> menuItems = new List<Text>();
    //public Text rus, eng;
    private Coroutine coro;
    

    public MenuMain menuMain;
    // Use this for initialization
    void Start () {
		//menuItems.Add(rus);
		//menuItems.Add(eng);
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {

	        if (coro == null)
	        {
	            coro=StartCoroutine(pressBack());

            }
	        
	    }
    }

    private IEnumerator pressBack()
    {
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(aktogay2Screen, mainMenuScreen));
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        menu.SetActive(false);
        input.rotationX = menuMain.lastRotations;
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        aktogay2Screen.gameObject.SetActive(false);
        menuMain.chooseTime = true;
        gameObject.SetActive(false);
        coro = null;
    }

    public void Click()
    {
        
    }

    public void Back()
    {
        if (coro == null)
        {
            coro = StartCoroutine(pressBack());

        }
    }
}
