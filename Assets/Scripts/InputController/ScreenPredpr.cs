using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPredpr : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public List<TextMeshProUGUI> optionRus;
    public List<TextMeshProUGUI> optionEng;
    public List<GameObject> screens;
    public List<GameObject> option;
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

    public GameObject mainMenuScreen, selectorMainMenu, predprScreen, mainMenuController;
    public GameObject menu;
    public List<TextMeshProUGUI> menuItems = new List<TextMeshProUGUI>();
    public MenuMain menuMain;
    private Coroutine coro;
    private List<GameObject> list = new List<GameObject>();

    public List<Image> slidesBozshak, slidesAktogay, slidesBozim, slidesEast;
    private int currentSlide = 0;
    private int nextSlide;
    private float durationChangeScreen = 0.5f;
    private Coroutine coroSlider;
    public List<List<Image>> listImages = new List<List<Image>>();


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < optionRus.Count; i++)
        {
            unselectListRusFull.Add(optionRus[i].gameObject);
            unselectListEngFull.Add(optionEng[i].gameObject);
            menuItems.Add(optionRus[i]);
            menuItems.Add(optionEng[i]);
        }

        listImages.Add(slidesBozshak);
        listImages.Add(slidesAktogay);
        listImages.Add(slidesBozim);
        listImages.Add(slidesEast);

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
            if (coro == null)
            {
                chooseTime = false;
                coro = StartCoroutine(pressBack());
            }
        }
    }

    public void Back()
    {
       
    }

    public void startSlider()
    {
        listImages[0][0].transform.localPosition = Vector3.zero;
        coroSlider = StartCoroutine(slider(listImages[0]));
    }

    private IEnumerator slider(List<Image> images)
    {
        currentSlide = 0;
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(SlideImageBack(images));
        }
    }

    public IEnumerator SlideImageBack(List<Image> images)
    {
        //while (isSlide)
        //{
        //    yield return new WaitForSeconds(slideTime);
        nextSlide = currentSlide + 1 == images.Count ? 0 : currentSlide + 1;
        yield return StartCoroutine(changeScreenBack(images[currentSlide].gameObject, images[nextSlide].gameObject));
        currentSlide = nextSlide;

        //}
    }

    public IEnumerator changeScreenBack(GameObject currentScreen, GameObject nextScreen)
    {
        Vector3 currentPos = Vector3.zero;
        Vector3 nextPos = new Vector3(-987, 0, 0);
        nextScreen.transform.position = nextPos;
        nextScreen.SetActive(true);
        float time = 0;
        while (time < durationChangeScreen)
        {
            time += Time.deltaTime;
            if (time < durationChangeScreen)
            {
                //y = sin2(sin2(x * pi / 2) * pi / 2)
                float x = Mathf.Sin(Mathf.PI * time / (2 * durationChangeScreen)) *
                          Mathf.Sin(Mathf.PI * time / (2 * durationChangeScreen));
                currentPos.x = 987 * Mathf.Sin(Mathf.PI * x / 2) * Mathf.Sin(Mathf.PI * x / 2);
                nextPos.x = -987 + currentPos.x;
                currentScreen.transform.localPosition = currentPos;
                nextScreen.transform.localPosition = nextPos;
            }
            else
            {
                currentScreen.transform.localPosition = new Vector3(987, 0, 0);
                nextScreen.transform.localPosition = Vector3.zero;
            }


            yield return null;
        }

        currentScreen.transform.localPosition = new Vector3(-987, 0, 0);
        nextScreen.transform.localPosition = Vector3.zero;
    }

    public void GetFocus(float value)
    {
        newPos = (int) (value / 30);
        if (selectMainPos != newPos)
        {
            for (int i = 0; i < optionRus.Count; i++)
            {
                optionRus[i].fontMaterial = MaterialsController.inst.simple;
                optionEng[i].fontMaterial = MaterialsController.inst.simple;
                optionRus[i].color = input.unselectedColor;
                optionEng[i].color = input.unselectedColor;
            }

            optionRus[newPos].fontMaterial = MaterialsController.inst.glow;
            optionEng[newPos].fontMaterial = MaterialsController.inst.glow;
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


            chooseTime = false;
            list.Clear();
            list.AddRange(option);
            list.RemoveAt(newPos);
            coroEng = StartCoroutine(
                AnimationController.inst.SelectItem(option[newPos], list));
            //coroRus = StartCoroutine(
            //    AnimationController.inst.SelectItem(optionRus[newPos].gameObject, unselectListRus));
            //coroEng = StartCoroutine(
            //    AnimationController.inst.SelectItem(option[newPos], unselectListEng));
            dinamicMapItems[selectMainPos].Off();
            dinamicMapItems[newPos].gameObject.SetActive(true);
            dinamicMapItems[newPos].On();
            //if (selectMainPos < newPos || (selectMainPos == 3 && newPos == 0))
            //{
            StartCoroutine(AnimationController.inst.changeScreenBack(screens[selectMainPos], screens[newPos]));
            StopCoroutine(coroSlider);
            StartCoroutine(changeScreenBack(listImages[selectMainPos][currentSlide].gameObject,
                listImages[newPos][0].gameObject));
            coroSlider = StartCoroutine(slider(listImages[newPos]));

            //}
            //else
            //{
            //    StartCoroutine(AnimationController.inst.changeScreen(screens[selectMainPos], screens[newPos]));
            //
            //}
            chooseTime = true;
            selectMainPos = newPos;
        }
    }

    private IEnumerator pressBack()
    {
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StopCoroutine(coroSlider);
        StartCoroutine(AnimationController.inst.changeScreenBack(predprScreen, mainMenuScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        for (int i = 0; i < listImages.Count; i++)
        {
            for (int j = 0; j < listImages[i].Count; j++)
            {
                listImages[i][j].transform.localPosition = new Vector3(-987, 0, 0);
            }
        }

        //selectMainPos = 0;
        menu.SetActive(false);
        chooseTime = false;
        input.rotationX = menuMain.lastRotations;
        dinamicMap.SetActive(false);
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));
        for (int i = 0; i < dinamicMapItems.Count; i++)
        {
            dinamicMapItems[i].OffFast();
        }
        predprScreen.gameObject.SetActive(false);
        menuMain.chooseTime = true;
        startscreen();
        gameObject.SetActive(false);
        coro = null;
    }

    public void startscreen()
    {
        newPos = 0;
        for (int i = 0; i < optionRus.Count; i++)
        {

            optionRus[i].fontMaterial = MaterialsController.inst.simple;
            optionEng[i].fontMaterial = MaterialsController.inst.simple;
            optionRus[i].color = input.unselectedColor;
            optionEng[i].color = input.unselectedColor;
            screens[i].SetActive(false);
        }

        optionRus[newPos].fontMaterial = MaterialsController.inst.glow;
        optionEng[newPos].fontMaterial = MaterialsController.inst.glow;
        optionRus[newPos].color = input.selectedColor;
        optionEng[newPos].color = input.selectedColor;
        screens[newPos].SetActive(true);
        screens[newPos].transform.localPosition = Vector3.zero;
        for (int i = 0; i < dinamicMapItems.Count; i++)
        {
            dinamicMapItems[i].OffFast();
        }

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

        list.Clear();
        list.AddRange(option);
        list.RemoveAt(newPos);
        coroEng = StartCoroutine(
            AnimationController.inst.SelectItem(option[newPos], list));

        dinamicMapItems[newPos].OnFast();

        newPos = -1;
        selectMainPos = 0;
    }
}