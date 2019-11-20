using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static float[] allTimes;
    private static int[] allPoints;
    private static int[] deaths;

    private static int totalLevels;
    private static int currentLevel;

    private static string[] levels;
    private static string allResults;
    private static int currentGame = 0;

    public static void StartGame(string[] lvls, int game)
    {
        currentGame = game;
        levels = lvls;
        GameMgr.totalLevels = levels.Length;
        GameMgr.currentLevel = 0;
        GameMgr.allTimes = new float[GameMgr.totalLevels];
        GameMgr.allPoints = new int[GameMgr.totalLevels];
        GameMgr.deaths = new int[GameMgr.totalLevels];
    }

    ///Singleton
    private static GameMgr _instance;
    public static GameMgr Instance { get { return _instance; } }
    public static bool lastLevel()
    {
        if (currentLevel == totalLevels - 1) return true;
        else return false;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    //Singleton End

    // Start is called before the first frame update
    void Start()
    {

    }
    public static string GetScoreTable()
    {
        string scoreTable = "";
        for (int i = 0; i < totalLevels; i++)
        {
            scoreTable += "Level " + (i + 1).ToString() + " - " + (allPoints[i] + (int)allTimes[i]).ToString() + " Points   " + deaths[i] + " Deaths" + '\n';
        }
        return scoreTable;
    }

    public static void AddScore(int score, float timeLeft)
    {
        allTimes[currentLevel] = timeLeft;
        allPoints[currentLevel] = score;
        //NextLevel or GameOver(thank you for playing/instructions on questionnaire)
    }

    public static void AddDeath()
    {
        deaths[currentLevel] += 1;
    }

    public static string NextLevel()
    {
        currentLevel++;
        if (currentLevel >= totalLevels) return "Menu";
        return levels[currentLevel];
    }

    public static void SaveGameplayDataFromSession()
    {
        string results = currentGame.ToString() + "|";
        for (int i = 0; i < levels.Length; i++)
        {
            results +=(int)allTimes[i] + "|";
            results += allPoints[i] + "|";
            results += deaths[i] + "|";
        }
        results += "#";
        allResults += results;        
    }

    public static string GetGameplayData()
    {
        return allResults;
    }

    public static void CopyGameplayDataToClipboard()
    {
        var textEditor = new TextEditor();
        textEditor.text = allResults;
        textEditor.SelectAll();
        textEditor.Copy();
    }

}
