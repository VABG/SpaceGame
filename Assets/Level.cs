using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    enum LevelState {Start, Paused, Active, Won, Lost }

    LevelState levelState = LevelState.Start;
    public Player player;
    public Transform[] planets;
    private float time = 60;
    private int score;
    private float countdown = 4;
    private float timer = 0;
    bool justStarted = true;
    public Text UIScore;
    public Text UIFinalScore;
    public Text UITime;
    public Text UIInformation; //Reusable! Yay!
    // Start is called before the first frame update
    void Start()
    {
        Gravity.SetPlanets(planets);
        player.active = false;
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
        }
    }

    private void WinState()
    {
        //input etc
    }

    private void PauseState()
    {
        //input etc
    }

    private void LostState()
    {
        //Input etc
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

        if (justStarted && timer > 2)
        {
            justStarted = false;
            UIInformation.text = "";
        }


        if (time <= 0)
        {
            time = 0;
            Lose();
        }

        UITime.text = ((int)time).ToString();
    }

    public void Win()
    {
        player.Win();
        levelState = LevelState.Won;
        UIInformation.text = "You did it!";
        UIFinalScore.enabled = true;
        UIFinalScore.text = (score + (int)time).ToString();
        //Calculate score (time + score)
        GameMgr.AddScore(score, time);
        //check if last level
        //If so, go to thank you screen
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
        //Show text "You didn't make it, press space to retry level, escape to exit to menu (lose progress)"
    }

    public void Pause()
    {
        //show menu that gives option to restart, continue or exit (to menu)
        //Previous state should ALWAYS be 'Active'
    }

    public void Continue()
    {
        //Previous state should ALWAYS be 'Paused'
        levelState = LevelState.Active;
    }

    public void ExitToMenu()
    {
        //Change scene to level and reset
        SceneManager.LoadSceneAsync("Menu");
    }

    public void AddScore()
    {
        score += 5;
        UIScore.text = score.ToString();
        //Update UI
    }

    
    


}
