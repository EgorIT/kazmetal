using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGeography : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public List<TextMeshProUGUI> optionRus;
    public List<TextMeshProUGUI> optionEng;
    public List<GameObject> option;
    public List<GameObject> screens;

    public GameObject dinamicMap;
    public List<FactoryColors> dinamicMapItems;

    public bool chooseTime = false;

    public int selectMainPos = 0;
    private int newPos;
    private Coroutine coroRus = null;
    private Coroutine coroEng = null;
    private List<GameObject> unselectListRus = new List<GameObject>();
    private List<GameObject> unselectListEng = new List<GameObject>();
    private List<GameObject> unselectListRusFull = new List<GameObject>();
    private List<GameObject> unselectListEngFull = new List<GameObject>();

    public GameObject mainMenuScreen, selectorMainMenu, geographyScreen, mainMenuController;
    public GameObject menu;
    public List<TextMeshProUGUI> menuItems = new List<TextMeshProUGUI>();
    public MenuMain menuMain;
    private Coroutine coro, coroChan;
    private List<GameObject> list = new List<GameObject>();
    public List<GameObject> videoList;
    public List<LogoAnim> videos;
    

    // Use this for initialization
    void Start()
    {
        //Application.runInBackground = true;
        

        for (int i = 0; i < optionRus.Count; i++)
        {
            unselectListRusFull.Add(optionRus[i].gameObject);
            unselectListEngFull.Add(optionEng[i].gameObject);
            menuItems.Add(optionRus[i]);
            menuItems.Add(optionEng[i]);
        }
        //geographyScreen.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseTime)
        {
            GetFocus(input.rotationX + 59.0f);
        }
    }

    public void Click()
    {
        if (chooseTime)
        {
           
        }
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

    public void GetFocus(float value)
    {
        newPos = (int) (value / 30);
        if (selectMainPos != newPos)
        {
            StartCoroutine(changeGeog());
        }
    }

    private IEnumerator changeGeog()
    {
        for (int i = 0; i < optionRus.Count; i++)
        {
           
            optionRus[i].fontMaterial=  MaterialsController.inst.simple;
            optionEng[i].fontMaterial = MaterialsController.inst.simple;
        }

        optionRus[newPos].fontMaterial = MaterialsController.inst.glow;
        optionEng[newPos].fontMaterial = MaterialsController.inst.glow;
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
        chooseTime = false;
        //coroRus = StartCoroutine(
        //    AnimationController.inst.SelectItem(optionRus[newPos].gameObject, unselectListRus));
        //coroEng = StartCoroutine(
        //    AnimationController.inst.SelectItem(optionEng[newPos].gameObject, unselectListEng));
        list.Clear();
        list.AddRange(option);
        list.RemoveAt(newPos);
        coroEng = StartCoroutine(
            AnimationController.inst.SelectItem(option[newPos], list));
        
        //dinamicMapItems[newPos].gameObject.SetActive(true);
        //videoList[newPos].SetActive(true);
        dinamicMapItems[newPos].On();
        videos[newPos].PlayVideo();
        yield return StartCoroutine(dinamicMapItems[selectMainPos].OffCoroutine());
        videos[selectMainPos].StopVideo();
        //dinamicMapItems[selectMainPos].gameObject.SetActive(false);
        //videoList[selectMainPos].SetActive(false);
        //if (selectMainPos < newPos || (selectMainPos == 3 && newPos == 0))
        //{
        StartCoroutine(AnimationController.inst.changeScreenBack(screens[selectMainPos], screens[newPos]));
        StartCoroutine(AnimationController.inst.scaleVideoMinus(videoList[selectMainPos]));
        StartCoroutine(AnimationController.inst.scaleVideoPlus(videoList[newPos]));
        //}
        //else
        //{
        //    StartCoroutine(AnimationController.inst.changeScreen(screens[selectMainPos], screens[newPos]));
        //
        //}
        chooseTime = true;
        selectMainPos = newPos;
    }

    private IEnumerator pressBack()
    {
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(geographyScreen, mainMenuScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.SetActive(false);
        chooseTime = false;
        input.rotationX = menuMain.lastRotations;
        videos[selectMainPos].StopVideo();
        //dinamicMap.SetActive(false);
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        geographyScreen.gameObject.SetActive(false);
        menuMain.chooseTime = true;
        
        gameObject.SetActive(false);
        coro = null;
    }
}