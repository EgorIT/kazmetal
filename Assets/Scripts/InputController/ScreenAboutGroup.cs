﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAboutGroup : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public GameObject mainMenuScreen, selectorMainMenu, aboutGroupScreen,  mainMenuController;
	public GameObject menu;
    //public List<Text> menuItems = new List<Text>();
    //public Text rus, eng;
    public MenuMain menuMain;
    private Coroutine coro;
    public bool chooseTime = false;
    public int selectMainPos = 0;
    private int newPos;
    public List<Text> optionRus;
    public List<Text> optionEng;
    private Coroutine coroRus = null;
    private Coroutine coroEng = null;
    public List<GameObject> option;
    private List<GameObject> list = new List<GameObject>();
    public GameObject strategyScreen, otvetScreen;
    public GameObject strategyController, otvetController;
    public ScreenStrategy strategy;
    public ScreenOtvet otvet;




    // Use this for initialization
    void Start () {
        //menuItems.Add(rus);
        //menuItems.Add(eng);
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
                optionRus[0].color = input.selectedColor;
                optionEng[0].color = input.selectedColor;
                optionRus[1].color = input.unselectedColor;
                optionEng[1].color = input.unselectedColor;

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
                optionRus[1].color = input.selectedColor;
                optionEng[1].color = input.selectedColor;
                optionRus[0].color = input.unselectedColor;
                optionEng[0].color = input.unselectedColor;

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
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        menu.SetActive(false);
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
        StartCoroutine(selectMainPos == 0 ? startStrategy() : startOtvet());
    }

    private IEnumerator startStrategy()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(aboutGroupScreen, strategyScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.gameObject.SetActive(false);
        input.rotationX = -60f;
        strategyController.gameObject.SetActive(true);
        aboutGroupScreen.SetActive(false);
        strategy.chooseTime = true;
        gameObject.SetActive(false);
    }

    private IEnumerator startOtvet()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(aboutGroupScreen, otvetScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.gameObject.SetActive(false);
        input.rotationX = -60f;
        otvetController.gameObject.SetActive(true);
        aboutGroupScreen.gameObject.SetActive(false);
        aboutGroupScreen.SetActive(false);
        otvet.chooseTime = true;
        gameObject.SetActive(false);
    }

    public void Back()
    {
        if (coro == null)
        {
            coro = StartCoroutine(pressBack());
        }
    }
}
