using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public static AnimationController inst = null;
    public float durationScaleFocusMenuItem;
    public float durationChangeMenuItem;
    public float durationChangeScreen;
    public float durationScaleVideo;
    public float durationScaleVideoFast;
    private Color32 selectedColor = new Color32(255, 249, 203, 255);
    private Color32 unselectedColor = new Color32(26, 110, 157, 255);


    // Use this for initialization
    void Start()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst == this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator SelectItem(GameObject gObjSelect, List<GameObject> gObjUnselect)
    {
        float time = 0f;
        List<Vector3> startScaleUnselected = new List<Vector3>();
        //Vector3 unselect = new Vector3(0.04928f, 0.04928f, 0.04928f);
        Vector3 unselect = Vector3.one;
        Vector3 select = unselect * 1.2f;
        Vector3 startScaleSelected = gObjSelect.transform.localScale;
        for (int i = 0; i < gObjUnselect.Count; i++)
        {
            startScaleUnselected.Add(gObjUnselect[i].transform.localScale);
        }

        while (time < durationScaleFocusMenuItem)
        {
            time += Time.deltaTime;
            gObjSelect.transform.localScale =
                startScaleSelected + (select - startScaleSelected) * (time / durationScaleFocusMenuItem);

            for (int i = 0; i < gObjUnselect.Count; i++)
            {
                gObjUnselect[i].transform.localScale = startScaleUnselected[i] -
                                                       (startScaleUnselected[i] - unselect) *
                                                       (time / durationScaleFocusMenuItem);
            }

            yield return null;
        }

        gObjSelect.transform.localScale = select;
        for (int i = 0; i < gObjUnselect.Count; i++)
        {
            gObjUnselect[i].transform.localScale = unselect;
        }
    }

    public IEnumerator changeMenuHideOut2(List<Text> menuOutRus, List<Text> menuOutEng, int selectedItem)
    {
        float time = durationChangeMenuItem;
        while (time > 0)
        {
            for (int i = 0; i < menuOutRus.Count; i++)
            {
                selectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                unselectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                menuOutRus[i].color = i == selectedItem ? selectedColor : unselectedColor;
                menuOutEng[i].color = i == selectedItem ? selectedColor : unselectedColor;
            }

            yield return null;
            time -= Time.deltaTime;
        }
    }

    public IEnumerator changeMenuHideOut(List<Text> menuOut)
    {
        float time = durationChangeMenuItem;
        while (time > 0)
        {

            for (int i = 0; i < menuOut.Count; i++)
            {
                selectedColor.a = (byte)(255 * time / durationChangeMenuItem);
                menuOut[i].color = selectedColor;
            }
            time -= Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator changeMenuHideOut(List<Text> menuOut, int selectedItem)
    {
        float time = durationChangeMenuItem;
        while (time > 0)
        {
            
            for (int i = 0; i < menuOut.Count; i++)
            {
                selectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                unselectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                menuOut[i].color = i == selectedItem ? selectedColor : unselectedColor;
            }
            time -= Time.deltaTime;
            yield return null;
        }
    }
    
    public IEnumerator changeMenuShowIn2(List<Text> menuRus, List<Text> menuEng, int selectedItem)
    {
        float time = 0;
        while (time < durationChangeMenuItem)
        {
            
            for (int i = 0; i < menuRus.Count; i++)
            {
                selectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                unselectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                menuRus[i].color = i == selectedItem ? selectedColor : unselectedColor;
                menuEng[i].color = i == selectedItem ? selectedColor : unselectedColor;
            }
            time += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < menuRus.Count; i++)
        {
            selectedColor.a = 255;
            unselectedColor.a = 255;
            menuRus[i].color = i == selectedItem ? selectedColor : unselectedColor;
            menuEng[i].color = i == selectedItem ? selectedColor : unselectedColor;
        }
    }

    public IEnumerator changeMenuShowIn22(List<Text> menuRus, List<Text> menuEng, int selectedItem)
    {
        float time = 0;
        while (time < durationScaleVideoFast)
        {
            
            for (int i = 0; i < menuRus.Count; i++)
            {
                selectedColor.a = (byte) (255 * time / durationScaleVideoFast);
                unselectedColor.a = (byte) (255 * time / durationScaleVideoFast);
                menuRus[i].color = i == selectedItem ? selectedColor : unselectedColor;
                menuEng[i].color = i == selectedItem ? selectedColor : unselectedColor;
            }
            time += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < menuRus.Count; i++)
        {
            selectedColor.a = 255;
            unselectedColor.a = 255;
            menuRus[i].color = i == selectedItem ? selectedColor : unselectedColor;
            menuEng[i].color = i == selectedItem ? selectedColor : unselectedColor;
        }
    }

    public IEnumerator changeMenuShowIn(List<Text> menu)
    {
        float time = 0;
        while (time < durationChangeMenuItem)
        {

            for (int i = 0; i < menu.Count; i++)
            {
                selectedColor.a = (byte)(255 * time / durationChangeMenuItem);
                
                menu[i].color = selectedColor;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator changeMenuShowIn(List<Text> menu, int selectedItem)
    {
        float time = 0;
        while (time < durationChangeMenuItem)
        {
            
            for (int i = 0; i < menu.Count; i++)
            {
                selectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                unselectedColor.a = (byte) (255 * time / durationChangeMenuItem);
                menu[i].color = i == selectedItem ? selectedColor : unselectedColor;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator changeScreen(GameObject currentScreen, GameObject nextScreen)
    {
        Vector3 currentPos = Vector3.zero;
        Vector3 nextPos = new Vector3(1080, 0, 0);
        nextScreen.transform.position = nextPos;
        nextScreen.SetActive(true);
        float time = 0;
        while (time < durationChangeScreen)
        {
            time += Time.deltaTime;
            if (time < durationChangeScreen)
            {
                currentPos.x = -1080 * time / durationChangeScreen;
                nextPos.x = 1080 + currentPos.x;
                currentScreen.transform.localPosition = currentPos;
                nextScreen.transform.localPosition = nextPos;
            }
            else
            {
                currentScreen.transform.localPosition = new Vector3(-1080, 0, 0);
                nextScreen.transform.localPosition = Vector3.zero;
            }
            yield return null;
        }
        currentScreen.SetActive(false);
    }

    public IEnumerator changeScreenBack(GameObject currentScreen, GameObject nextScreen)
    {
        Vector3 currentPos = Vector3.zero;
        Vector3 nextPos = new Vector3(-1080, 0, 0);
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
                currentPos.x = 1080* Mathf.Sin(Mathf.PI * x / 2) * Mathf.Sin(Mathf.PI * x / 2);
                nextPos.x = -1080 + currentPos.x;
                currentScreen.transform.localPosition = currentPos;
                nextScreen.transform.localPosition = nextPos;
            }
            else
            {
                currentScreen.transform.localPosition = new Vector3(-1080, 0, 0);
                nextScreen.transform.localPosition = Vector3.zero;
            }

            
            yield return null;
        }
        currentScreen.transform.localPosition = new Vector3(-1080, 0, 0);
        nextScreen.transform.localPosition = Vector3.zero;
        currentScreen.SetActive(false);
    }

    public IEnumerator scaleVideoPlus(GameObject obj)
    {
        float time = 0f;
        float scale = 0f;
        while (time < durationScaleVideo)
        {
            time += Time.deltaTime;
            if (time < durationScaleVideo)
            {
                scale = time * time / durationScaleVideo / durationScaleVideo;
                obj.transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                obj.transform.localScale = Vector3.one;
            }

            yield return null;
        }
    }
    
    public IEnumerator scaleVideoMinus(GameObject obj)
    {
        float time = 0f;
        float scale = 0f;
        while (time < durationScaleVideo)
        {
            time += Time.deltaTime;
            if (time < durationScaleVideo)
            {
                scale = 1- time * time / durationScaleVideo / durationScaleVideo;
                obj.transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                obj.transform.localScale = Vector3.zero;
            }

            yield return null;
        }
    }

    public GameObject a;
   
    [ContextMenu("plus")]
    public void plus()
    {
        StartCoroutine(scaleVideoPlus(a));
    }
    [ContextMenu("minus")]
    public void minus()
    {
        StartCoroutine(scaleVideoMinus(a));
    }
}