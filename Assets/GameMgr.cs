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

    public string[] levels;

    public static void StartGame()
    {
        GameMgr.totalLevels = _instance.levels.Length;
        GameMgr.currentLevel = 0;
        GameMgr.allTimes = new float[GameMgr.totalLevels];
        GameMgr.allPoints = new int[GameMgr.totalLevels];
        GameMgr.deaths = new int[GameMgr.totalLevels];
    }

    ///Singleton
    private static GameMgr _instance;
    public static GameMgr Instance { get { return _instance; } }

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
            scoreTable += "Level" + (i + 1).ToString() + ": " + (allPoints[i] + (int)allTimes[i]).ToString() + " Deaths: " + deaths[i] + '\n';
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
        if (currentLevel >= totalLevels) return "Menu"; //TODO: Add final screen
        return _instance.levels[currentLevel];
    }

}
