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
    public List<GameObject> images;
    private float currentRotate;

    private int currentSlide = 0;
    private int nextSlide;
    private float durationChangeScreen = 0.5f;
    private Coroutine sliderCoro;

    



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
        //for (int j = 0; j < videos.Count; j++)
        //{
        //    StartCoroutine(videos[j].StartPrepareVideo());
        //}
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
            chooseTime = false;
            currentRotate = input.rotationX;
            StartCoroutine(changeGeog());
        }
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

        list.Clear();
        list.AddRange(option);
        list.RemoveAt(newPos);
        coroEng = StartCoroutine(
            AnimationController.inst.SelectItem(option[newPos], list));

        dinamicMapItems[newPos].OnFast();

        newPos = -1;
    }

    private IEnumerator changeGeog()
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
        //videos[newPos].PlayVideo();
        yield return StartCoroutine(dinamicMapItems[selectMainPos].OffCoroutine());
        
        //dinamicMapItems[selectMainPos].gameObject.SetActive(false);
        //videoList[selectMainPos].SetActive(false);
        //if (selectMainPos < newPos || (selectMainPos == 3 && newPos == 0))
        //{
        StartCoroutine(AnimationController.inst.changeScreenBack(screens[selectMainPos], screens[newPos]));
        StartCoroutine(swapVidos());
        //}
        //else
        //{
        //    StartCoroutine(AnimationController.inst.changeScreen(screens[selectMainPos], screens[newPos]));
        //
        //}
        
    }

    private IEnumerator swapVidos()
    {
        StartCoroutine(AnimationController.inst.scaleVideoPlus(videoList[newPos]));
        StartCoroutine(topVidosochanger(selectMainPos, newPos));
        yield return StartCoroutine(AnimationController.inst.scaleVideoMinus(videoList[selectMainPos]));
        
        //videos[selectMainPos].StopVideo();
        input.rotationX = currentRotate;
        chooseTime = true;
        selectMainPos = newPos;
    }

    private IEnumerator topVidosochanger(int current, int next)
    {
        
        if (current == 3)
        {
            videos[next].PlayVideo();
            yield return StartCoroutine(changeScreenBack(images[currentSlide].gameObject, videos[next].gameObject));
            StopCoroutine(sliderCoro);
            images[currentSlide].transform.position = new Vector3(-987,0,0);
            //images[currentSlide].gameObject.SetActive(false);
            currentSlide = 0;
        }
        else if (next == 3)
        {
            //images[0].gameObject.SetActive(true);
            sliderCoro = StartCoroutine(slider());
            yield return StartCoroutine(changeScreenBack(videos[current].gameObject, images[0].gameObject));
            videos[current].StopVideo();
            videos[current].transform.position = new Vector3(-987, 0, 0);
            
        }
        else
        {
            videos[next].PlayVideo();
            yield return StartCoroutine(changeScreenBack(videos[current].gameObject, videos[next].gameObject));
            videos[current].StopVideo();
        }

        yield return null;
    }

    private IEnumerator slider()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            yield return StartCoroutine(SlideImageBack());
        }
    }

    public IEnumerator SlideImageBack()
    {
        //while (isSlide)
        //{
        //    yield return new WaitForSeconds(slideTime);
        nextSlide = currentSlide + 1 == images.Count ? 0 : currentSlide + 1;
        yield return StartCoroutine(changeScreenBack(images[currentSlide], images[nextSlide]));
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

    private IEnumerator pressBack()
    {
        mainMenuScreen.gameObject.SetActive(true);
        mainMenuController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(geographyScreen, mainMenuScreen));
        yield return StartCoroutine(AnimationController.inst.changeMenuHideOut2(optionRus, optionEng, selectMainPos));
        menu.SetActive(false);
        chooseTime = false;
        input.rotationX = menuMain.lastRotations;
        //videos[selectMainPos].StopVideo();
        //dinamicMap.SetActive(false);
        selectorMainMenu.SetActive(true);
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(menuMain.optionRus, menuMain.optionEng, menuMain.selectMainPos));

        for (int i = 0; i < videoList.Count; i++)
        {
            videoList[i].transform.localScale = Vector3.zero;
        }
        for (int i = 0; i < dinamicMapItems.Count; i++)
        {
            dinamicMapItems[i].OffFast();
        }

        for (int i = 0; i < videos.Count; i++)
        {
            videos[i].StopVideo();
            videos[i].transform.localPosition = new Vector3(-987, 0, 0);
        }

        videos[0].transform.localPosition= new Vector3(0, 0, 0);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.localPosition = new Vector3(-987, 0, 0);
        }

        geographyScreen.gameObject.SetActive(false);
        menuMain.chooseTime = true;
        startscreen();
        gameObject.SetActive(false);
        coro = null;
    }


}