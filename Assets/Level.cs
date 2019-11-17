using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    enum LevelState {Start, Paused, Active, Won, Lost, FinalWin }

    LevelState levelState = LevelState.Start;
    private Player player;
    public Transform[] planets;
    private float time = 60;
    private int score;
    private float countdown = 4;
    private float timer = 0;
    bool justStarted = true;
    bool isChangingLevel = false;

    //In-game HUD
    public GameObject HUDInGameObject;
    public Text UIScore;
    public Text UITime;
    public Text UIInformation; //Reusable! Yay!

    //Score for all levlels
    public GameObject UIScoreScreen;
    public Text UITotalScore;

    //Final score for last level
    public GameObject UIFinalScreen;
    public Text UIFinalScore;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Gravity.SetPlanets(planets);
        player.active = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch(levelState)
        {
            case LevelState.Active:
                ActiveState();
                break;

            case LevelState.Paused:
                PauseState();
                break;

            case LevelState.Won:
                WinState();
                break;

            case LevelState.Lost:
                LostState();
                break;

            case LevelState.Start:
                StartState();
                break;


            case LevelState.FinalWin:
                FinalWinState();
                break;
        }
    }

    private void WinState()
    {
        //input etc? Or just delay + show score calculation?
        if (countdown < 0)
        {
            //Show next level button instead!
            if (!isChangingLevel)
            {
                if (Input.GetKeyDown(KeyCode.Space)) NextLevel();
            }
        }
        if (countdown > 3)
        {
            UITotalScore.text = "Score: " + score.ToString() + " + Time: " + ((int)time).ToString();
        }
        else
        {
            UITotalScore.text = "Total Score: " + (score + (int)time).ToString();
        }
        countdown -= Time.deltaTime;
    }

    public void SetFinalWin()
    {
        levelState = LevelState.FinalWin;        
        UIFinalScreen.SetActive(true);
        UIFinalScore.text = GameMgr.GetScoreTable();
    }

    public void NextLevel()
    {
        if (!GameMgr.lastLevel())
        {
            string nextLevel = GameMgr.NextLevel();            
            SceneManager.LoadSceneAsync(nextLevel);
            isChangingLevel = true;
        }
        else
        {
            //Hide everything exept for final score menu
            SetFinalWin();
            UIScoreScreen.SetActive(false);
            UIFinalScreen.SetActive(true);
        }
    }

    private void FinalWinState()
    {
        if (!isChangingLevel && Input.GetKeyDown(KeyCode.Space)) NextLevel();
    }

    private void PauseState()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Continue();
        if (Input.GetKeyDown(KeyCode.Escape)) ExitToMenu();
    }

    private void LostState()
    {
        //Wait for input (escape to give up, space to continue(retry))
        if (Input.GetKeyDown(KeyCode.Space)) RestartLevel();
        if (Input.GetKeyDown(KeyCode.Escape)) ExitToMenu();
    }

    private void StartState()
    {
        //Do countdown
        countdown -= Time.deltaTime;
        UIInformation.text = ((int)countdown).ToString();
        if (countdown < 1) StartGame();
    }

    private void ActiveState()
    {
        //Input etc
        time -= Time.deltaTime;
        timer += Time.deltaTime;

        if (justStarted && timer > 1)
        {
            justStarted = false;
            UIInformation.text = "";
        }

        if (time <= 0)
        {
            time = 0;
            Lose();
        }

        if (player.dead)
        {
            Lose();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
        UITime.text = ((int)time).ToString();
    }

    public void Win()
    {
        if (player.dead) return;
        player.Win();
        levelState = LevelState.Won;
        UIInformation.text = "You did it!";
        UIScoreScreen.SetActive(true);
        UITotalScore.text = (score + (int)time).ToString();
        //Calculate score (time + score)
        countdown = 5;
        GameMgr.AddScore(score, time);

        HUDInGameObject.SetActive(false);
    }

    public void StartGame()
    {
        levelState = LevelState.Active;
        player.active = true;
        UIInformation.text = "Start!";
    }

    public void Lose()
    {
        if (player.active) player.Die();
        levelState = LevelState.Lost;
        string s = "You didn't make it, press SPACE to retry!" + '\n' + "Press escape to exit to menu (lose all progress).";
        UIInformation.text = s;
        //Show text "You didn't make it, press space to retry level, escape to exit to menu (lose progress)"        
    }

    public void Pause()
    {
        //show menu that gives option to restart, continue or exit (to menu)
        UIInformation.text = "Press space to continue. Press escape to exit to menu (lose progress)";
        levelState = LevelState.Paused;
        Time.timeScale = 0;
        //Previous state should ALWAYS be 'Active'
    }

    public void Continue()
    {
        //Previous state should ALWAYS be 'Paused'
        UIInformation.text = "";
        levelState = LevelState.Active;
        Time.timeScale = 1;
    }

    public void ExitToMenu()
    {
        //Change scene to level and reset (needs menu scene)
        SceneManager.LoadSceneAsync("Menu");
    }

    public void AddScore()
    {
        score += 5;
        UIScore.text = score.ToString();
    }

    private void RestartLevel()
    {
        //Make level restartable somehow
        //Reload level? (seems to be working just fine)
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    


}
