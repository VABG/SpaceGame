using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject UI;
    public string questionnaireURL;
    public string[] cartoonLevels;
    public string[] realisticLevels;

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
        GameMgr.StartGame(cartoonLevels);
        SceneManager.LoadSceneAsync(cartoonLevels[0]);
    }

    public void StartGame2()
    {
        HideUI();
        GameMgr.StartGame(realisticLevels);
        SceneManager.LoadSceneAsync(realisticLevels[0]);
    }

    private void HideUI()
    {
        UI.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        //EditorApplication.ExitPlaymode();
    }

    public void GotoQuestionnaire()
    {
        Application.OpenURL(questionnaireURL);
    }
}
