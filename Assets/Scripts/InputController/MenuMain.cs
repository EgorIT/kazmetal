using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMain : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public List<Text> optionRus;
    public List<Text> optionEng;
    public List<GameObject> option;
    public int selectMainPos = -1;
    public GameObject selectorLang, selectorMain,  selectorGeography;
    public GameObject selectorLangController, selectorMainController;// selectorBack;
    public GameObject mainMemuScreen;
    public GameObject aboutGroup, actogay2, geography, predpr, future;
    public GameObject aktogay2Controller, aboutGroupController, geographyController, predprController, futureController;
    private int newPos;
    private Coroutine coroRus = null;
    private Coroutine coroEng = null;
    private List<GameObject> unselectListRus = new List<GameObject>();
    private List<GameObject> unselectListEng = new List<GameObject>();
    private List<GameObject> unselectListRusFull = new List<GameObject>();
    private List<GameObject> unselectListEngFull = new List<GameObject>();
    public bool chooseTime = false;
    public MenuLang menuLang;
    public ScreenAktogay2 screenAktogay2;
    public ScreenAboutGroup screenAboutGroup;
    public ScreenGeography screenGeography;
    public ScreenPredpr screenPredpr;
    public ScreenFuture screenFuture;
    private List<GameObject> list = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < optionRus.Count; i++)
        {
            unselectListRusFull.Add(optionRus[i].gameObject);
            unselectListEngFull.Add(optionEng[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseTime)
        {
            GetFocus(input.rotationX + 59f);
            //if (Input.GetMouseButtonDown(0))
            //{
            //    
            //    switch (selectMainPos)
            //    {
            //        case 0:
            //
            //            break;
            //        case 1:
            //
            //            break;
            //        case 2:
            //
            //            break;
            //        case 3:
            //            chooseTime = false;
            //            StartCoroutine(selectAboutGroup());
            //            //aboutGroup.gameObject.SetActive(true);
            //            //aboutGroupController.gameObject.SetActive(true);
            //            //selectorBack.SetActive(true);
            //            //selectorMain.gameObject.SetActive(false);
            //            //mainMemuScreen.gameObject.SetActive(false);
            //            //gameObject.SetActive(false);
            //            break;
            //        case 4:
            //            chooseTime = false;
            //            /*selectorLang.gameObject.SetActive(true);
            //            selectorLangController.gameObject.SetActive(true);
            //
            //            selectorMain.gameObject.SetActive(false);
            //            selectorMainController.gameObject.SetActive(false);*/
            //            StartCoroutine(changeMenuBack());
            //            break;
            //        case 5:
            //            chooseTime = false;
            //            StartCoroutine(selectAktogay2());
            //            //gameObject.SetActive(false);
            //            break;
            //    }
            //}

            
        }
    }

    public void GetFocus(float value)
    {
        newPos = (int) (value / 24);
        if (selectMainPos != newPos)
        {
            for (int i = 0; i < optionRus.Count; i++)
            {
                optionRus[i].color = input.unselectedColor;
                optionEng[i].color = input.unselectedColor;
            }

            optionRus[newPos].color = input.selectedColor;
            optionEng[newPos].color = input.selectedColor;
            if (coroRus != null)
            {
                StopCoroutine(coroRus);
            }

            if (coroEng != null)
            {
                StopCoroutine(coroEng);
            }

            unselectListEng.Clear();
            unselectListRus.Clear();

            unselectListEng.AddRange(unselectListEngFull);
            unselectListRus.AddRange(unselectListRusFull);

            unselectListEng.RemoveAt(newPos);
            unselectListRus.RemoveAt(newPos);

            //coroRus = StartCoroutine(
            //    AnimationController.inst.SelectItem(option[newPos].gameObject, unselectListRus));
            //coroEng = StartCoroutine(
            //    AnimationController.inst.SelectItem(optionEng[newPos].gameObject, unselectListEng));
            list.Clear();
            list.AddRange(option);
            list.RemoveAt(newPos);
                coroEng = StartCoroutine(
                AnimationController.inst.SelectItem(option[newPos], list));

            selectMainPos = newPos;
        }
    }

    private IEnumerator changeMenuBack()
    {
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorLang.gameObject.SetActive(true);
        selectorMain.gameObject.SetActive(false);
        
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn(menuLang.texts, menuLang.select ? 0 : 1));
        menuLang.chooseTime = true;
        selectorLangController.SetActive(true);
    }

    private IEnumerator selectAktogay2()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(mainMemuScreen, actogay2));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorMain.gameObject.SetActive(false);
        //selectorBack.SetActive(true);
        //yield return StartCoroutine(AnimationController.inst.changeMenuShowIn(screenAktogay2.menuItems));
        aktogay2Controller.gameObject.SetActive(true);
        mainMemuScreen.gameObject.SetActive(false);
        
    }

    private IEnumerator selectAboutGroup()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(mainMemuScreen, aboutGroup));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorMain.gameObject.SetActive(false);
        //selectorBack.SetActive(true);
        //yield return StartCoroutine(AnimationController.inst.changeMenuShowIn(screenAboutGroup.menuItems));
        aboutGroupController.gameObject.SetActive(true);
        mainMemuScreen.gameObject.SetActive(false);

    }

    private IEnumerator selectGeography()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(mainMemuScreen, geography));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorMain.gameObject.SetActive(false);
        selectorGeography.SetActive(true);
        input.rotationX = -60f;
        geographyController.gameObject.SetActive(true);
        
        yield return StartCoroutine(AnimationController.inst.changeMenuShowIn2(screenGeography.optionRus, screenGeography.optionEng, 0));
        //screenGeography.dinamicMap.SetActive(true);
        //for (int i = 0; i < screenGeography.dinamicMapItems.Count; i++)
        //{
        //    screenGeography.dinamicMapItems[i].Off();
        //}
        //screenGeography.dinamicMapItems[0].On();
        screenGeography.chooseTime = true;
        mainMemuScreen.gameObject.SetActive(false);

    }

    private IEnumerator selectPredpr()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(mainMemuScreen, predpr));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorMain.gameObject.SetActive(false);
        selectorGeography.SetActive(true);
        input.rotationX = -60f;
        predprController.gameObject.SetActive(true);
        yield return StartCoroutine(AnimationController.inst.changeMenuShowIn2(screenPredpr.optionRus, screenPredpr.optionEng, 0));
        screenPredpr.dinamicMap.SetActive(true);
        for (int i = 0; i < screenPredpr.dinamicMapItems.Count; i++)
        {
            screenPredpr.dinamicMapItems[i].Off();
        }
        screenPredpr.dinamicMapItems[0].On();
        screenPredpr.chooseTime = true;
        mainMemuScreen.gameObject.SetActive(false);

    }
    
    private IEnumerator selectFuture()
    {
        chooseTime = false;
        StartCoroutine(AnimationController.inst.changeScreenBack(mainMemuScreen, future));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        selectorMain.gameObject.SetActive(false);
        //selectorGeography.SetActive(true);
        input.rotationX = -60f;
        futureController.gameObject.SetActive(true);
        //yield return StartCoroutine(AnimationController.inst.changeMenuShowIn2(screenPredpr.optionRus, screenPredpr.optionEng, 0));
        //screenPredpr.dinamicMap.SetActive(true);
        //for (int i = 0; i < screenPredpr.dinamicMapItems.Count; i++)
        //{
        //    screenPredpr.dinamicMapItems[i].Off();
        //}
        //screenPredpr.dinamicMapItems[0].On();
        screenFuture.chooseTime = true;
        mainMemuScreen.gameObject.SetActive(false);

    }

    public void Click()
    {
        if (chooseTime)
        {
            switch (selectMainPos)
            {
                case 0:
                    chooseTime = false;
                    StartCoroutine(selectGeography());
                    break;
                case 1:
                    //chooseTime = false;
                    //StartCoroutine(selectPredpr());
                    break;
                case 2:
                    chooseTime = false;
                    StartCoroutine(selectFuture());
                    break;
                case 3:
                    chooseTime = false;
                    StartCoroutine(selectAboutGroup());
                    break;
                case 4:
                    chooseTime = false;
                    StartCoroutine(selectAktogay2());
                    break;

            }
        }
    }

    public void Back()
    {
        if (chooseTime)
        {
            chooseTime = false;
            StartCoroutine(changeMenuBack());
        }
    }
}