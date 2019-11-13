﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject UI;
    public string questionnaireURL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame1()
    {
        HideUI();
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void StartGame2()
    {
        HideUI();
        SceneManager.LoadSceneAsync("SampleScene");
    }

    private void HideUI()
    {
        UI.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();   
    }

    public void GotoQuestionnaire()
    {
        Application.OpenURL(questionnaireURL);
    }
}