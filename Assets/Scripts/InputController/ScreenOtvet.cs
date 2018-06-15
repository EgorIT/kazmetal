﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ScreenOtvet : MonoBehaviour, InputInteface
{
    public InputCustomController input;
    public bool chooseTime = false;
    public ScreenAboutGroup aboutGroup;
    public GameObject otvetScreen;
    public GameObject aboutGroupScreen;
    public GameObject aboutGroupController;
    public GameObject selectorAboutGroup;
    public GameObject content;
    private Vector3 startPos;
    private Vector3 endPos = new Vector3(0, 890, 0);
    private Coroutine coro;

    public LogoAnim logoAnim;
    


    // Use this for initialization
    void Start()
    {
        startPos = content.transform.localPosition;
        
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator pressBack()
    {
        aboutGroupScreen.gameObject.SetActive(true);
        aboutGroupController.gameObject.SetActive(true);
        StartCoroutine(AnimationController.inst.changeScreenBack(otvetScreen, aboutGroupScreen));
        //yield return StartCoroutine(AnimationController.inst.changeMenuHideOut(menuItems));
        //menu.SetActive(false);
        input.rotationX = aboutGroup.lastRotations;
        selectorAboutGroup.SetActive(true);
        logoAnim.StopVideo();
        yield return StartCoroutine(
            AnimationController.inst.changeMenuShowIn2(aboutGroup.optionRus, aboutGroup.optionEng,
                aboutGroup.selectMainPos));
        otvetScreen.gameObject.SetActive(false);
        aboutGroup.chooseTime = true;
        gameObject.SetActive(false);
    }

    public void Click()
    {
    }

    public void Back()
    {
        chooseTime = false;
        if (coro != null)
        {
            StopCoroutine(coro);
        }
        StartCoroutine(pressBack());
    }
    [ContextMenu("scroll")]
    public void startScroll()
    {
        coro = StartCoroutine(AnimationController.inst.scrollContentOtvet(startPos, endPos, content));
    }
}