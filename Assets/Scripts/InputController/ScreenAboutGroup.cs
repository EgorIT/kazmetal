using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAboutGroup : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public GameObject mainMenuScreen, selectorMainMenu, aboutGroupScreen,  mainMenuController;
	public GameObject menu;
    public List<TextMeshProUGUI> menuItems = new List<TextMeshProUGUI>();
    //public Text rus, eng;
    public MenuMain menuMain;
    private Coroutine coro;
    public bool chooseTime = false;
    public int selectMainPos = 0;
    private int newPos;
    public List<TextMeshProUGUI> optionRus;
    public List<TextMeshProUGUI> optionEng;
    private Coroutine coroRus = null;
    private Coroutine coroEng = null;
    public List<GameObject> option;
    private List<GameObject> list = new List<GameObject>();
    public GameObject strategyScreen, otvetScreen;
    public GameObject strategyController, otvetController;
    public ScreenStrategy strategy;
    public ScreenOtvet otvet;
    public float lastRotations;




    // Use this for initialization
    void Start () {
        menuItems.AddRange(optionRus);
        menuItems.AddRange(optionEng);
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (chooseTime)
        {
            GetFocus(input.rotationX + 59.0f);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (coro == null)
        //    {
        //        coro = StartCoroutine(pressBack());
        //    }
        //    //mainMenuScreen.gameObject.SetActive(true);
        //    //selectorMainMenu.gameObject.SetActive(true);
        //    //mainMenuController.gameObject.SetActive(true);
        //    //aboutGroupScreen.gameObject.SetActive(false);
	    //    //menu.gameObject.SetActive(false);
        //    //gameObject.SetActive(false);
        //    //menuMain.chooseTime = true;
        //}
    }

    public void GetFocus(float value)
    {
        
        newPos = (int)(value / 30);
        if (selectMainPos!=newPos)
        {
            if (newPos % 2 == 0)
            {
                
                optionRus[0].fontMaterial =  MaterialsController.inst.glow;
                optionEng[0].fontMaterial = MaterialsController.inst.glow;
                optionRus[1].fontMaterial = MaterialsController.inst.simple;
                optionEng[1].fontMaterial = MaterialsController.inst.simple;

                if (coroEng != null)
                {
                    StopCoroutine(coroEng);
                }
                list.Clear();
                list.Add(option[1]);
                coroEng = StartCoroutine(AnimationController.inst.SelectItem(option[0], list));
            }
            else
            {
                optionRus[1].fontMaterial =  MaterialsController.inst.glow;
                optionEng[1].fontMaterial = MaterialsController.inst.glow;
                optionRus[0].fontMaterial = MaterialsController.inst.simple;
                optionEng[0].fontMaterial = MaterialsController.inst.simple;

                if (coroEng != null)
                {
                    StopCoroutine(coroEng);
                }
                list.Clear();
                list.Add(option[0]);
                coroEng = StartCoroutine(AnimationController.inst.SelectItem(option[1], list));
            }

            selectMainPos = newPos;
        }
        
    }

    private IEnumerator pressBack()
    {
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(aboutGroupScreen, mainMenuScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, 0));
        menu.SetActive(false);
        input.rotationX = menuMain.lastRotations;
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn22(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        aboutGroupScreen.gameObject.SetActive(false);
        menuMain.chooseTime = true;
        gameObject.SetActive(false);
        coro = null;
    }

    public void Click()
    {
        StartCoroutine(selectMainPos == 1 ? startStrategy() : startOtvet());
    }

    private IEnumerator startStrategy()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(aboutGroupScreen, strategyScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.gameObject.SetActive(false);
        lastRotations = input.rotationX;
        input.rotationX = -60f;
        strategyController.gameObject.SetActive(true);
        aboutGroupScreen.SetActive(false);
        strategy.chooseTime = true;
        strategy.startScroll();
        gameObject.SetActive(false);
    }

    private IEnumerator startOtvet()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(aboutGroupScreen, otvetScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.gameObject.SetActive(false);
        lastRotations = input.rotationX;
        input.rotationX = -60f;
        otvetController.gameObject.SetActive(true);
        aboutGroupScreen.gameObject.SetActive(false);
        aboutGroupScreen.SetActive(false);
        otvet.chooseTime = true;
        otvet.startScroll();
        otvet.logoAnim.StartPrepareVideo();
        otvet.logoAnim.PlayVideo();
        gameObject.SetActive(false);
    }

    public void Back()
    {
        if (chooseTime)
        {
            if (coro == null)
            {
                chooseTime = false;
                coro = StartCoroutine(pressBack());
            }
        }
        
    }
}
