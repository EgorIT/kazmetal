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
    public GameObject model;
    public bool chooseTime = false;
    public int selectMainPos = 0;
    private int newPos;
    public float durationRotate;

    public MenuMain menuMain;
    // Use this for initialization
    void Start () {
		//menuItems.Add(rus);
		//menuItems.Add(eng);
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (chooseTime)
	    {
	        GetFocus(input.rotationX + 59.0f);
	    }
    }

    public void GetFocus(float value)
    {
        newPos = (int)(value / 24);
        if (selectMainPos != newPos)
        {
            chooseTime = false;
            if ((newPos == selectMainPos + 1))
            {

                StartCoroutine(rotate(model, selectMainPos*72+24, 1));
            }
            if ((newPos == 0 && selectMainPos == 4))
            {

                StartCoroutine(rotate(model, selectMainPos * 72 + 24, 1));
            }
            if ((newPos == selectMainPos - 1))
            {

                StartCoroutine(rotate(model, selectMainPos * 72 + 24, -1));
            }
            if ((newPos == 4 && selectMainPos == 0))
            {

                StartCoroutine(rotate(model, selectMainPos * 72 + 24, -1));
            }
            selectMainPos = newPos;
            
        }
    }


    public IEnumerator rotate(GameObject gameObject1, float current, int koef)
    {
        float time = 0f;
        Vector3 rotat;
        while (time < durationRotate)
        {
            //y = sin2(sin2(x * pi / 2) * pi / 2)
            float x = Mathf.Sin(Mathf.PI * time / (2 * durationRotate)) *
                      Mathf.Sin(Mathf.PI * time / (2 * durationRotate));
            rotat = new Vector3(0, current + koef * 72 * Mathf.Sin(Mathf.PI * x / 2) * Mathf.Sin(Mathf.PI * x / 2), 0);
            gameObject1.transform.rotation = Quaternion.Euler(rotat);
            time += Time.deltaTime;

            yield return null;
        }
        gameObject1.transform.rotation = Quaternion.Euler(new Vector3(0, current + 72 * koef, 0));
        chooseTime = true;
    }


    private IEnumerator pressBack()
    {
        chooseTime = false;
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(aktogay2Screen, mainMenuScreen));
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        menu.SetActive(false);
        input.rotationX = menuMain.lastRotations;
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        model.transform.localRotation = Quaternion.Euler(new Vector3(0, 24 , 0));
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
