using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject UI;
    public string questionnaireURL;
    public string[] cartoonLevels;
    public string[] realisticLevels;
    public Text gameToPlay;
    public Text gameplayData;
    public static int StartGame = 0;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        if (StartGame == 0) StartGame = Random.Range(1, 3);
        gameToPlay.text = "Play Game " + StartGame.ToString() + " First!";
        gameplayData.text = GameMgr.GetGameplayData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame1()
    {
        HideUI();
        GameMgr.StartGame(cartoonLevels, 1);
        SceneManager.LoadSceneAsync(cartoonLevels[0]);
    }

    public void StartGame2()
    {
        HideUI();
        GameMgr.StartGame(realisticLevels, 2);
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

    public void CopyDataToClipboard()
    {
        GameMgr.CopyGameplayDataToClipboard();
    }
}
