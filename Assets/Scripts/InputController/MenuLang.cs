﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLang : MonoBehaviour, InputInteface
{
    public GameObject selectorLang, selectorMain;
    public Text textRus, textEng;
    public GameObject textRusC, textEngC;
    public InputCustomController input;
    public ChangeLang changeLang;
    public GameObject menuMainController;
    public Coroutine coro = null;
    public bool select = false;
    private List<GameObject> unselectList = new List<GameObject>();
    public bool chooseTime = true;
    public MenuMain menuMain;
    public List<Text> texts = new List<Text>();
    


    // Use this for initialization
    void Start()
    {
        texts.Add(textRus);
        texts.Add(textEng);
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseTime)
        {
            int a = (int) (input.rotationX + 59) / 20;
            if (a%2==0)
            {
                FocusEng();
                if (select)
                {
                    select = false;
                    if (coro != null)
                    {
                        StopCoroutine(coro);
                    }

                    unselectList.Clear();
                    unselectList.Add(textRusC);
                    coro = StartCoroutine(AnimationController.inst.SelectItem(textEngC, unselectList));
                }
            }
            else
            {
                FocusRus();
                if (!select)
                {
                    select = true;
                    if (coro != null)
                    {
                        StopCoroutine(coro);
                    }

                    unselectList.Clear();
                    unselectList.Add(textEngC);
                    coro = StartCoroutine(AnimationController.inst.SelectItem(textRusC, unselectList));
                }
            }

            //if (Input.GetMouseButtonDown(0))
            //{
            //    chooseTime = false;
            //    StartCoroutine(changeMenu());
            //}
        }
    }

    

    private void FocusEng()
    {
        textEng.color = input.selectedColor;
        textRus.color = input.unselectedColor;
        changeLang.SelectEng();
    }

    private void FocusRus()
    {
        textEng.color = input.unselectedColor;
        textRus.color = input.selectedColor;
        changeLang.SelectRus();
    }

    private IEnumerator changeMenu()
    {
        
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(texts, select ? 0 : 1));
        selectorLang.gameObject.SetActive(false);
        selectorMain.gameObject.SetActive(true);
        // menuMainController.gameObject.SetActive(true);
        input.rotationX = -60f;
        menuMain.GetFocus(input.rotationX + 59.0f);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        menuMain.chooseTime = true;
        
        gameObject.SetActive(false);
    }

   
    public void Click()
    {
        if (chooseTime)
        {
            chooseTime = false;
            StartCoroutine(changeMenu());
        }
    }

    public void Back()
    {

    }
}