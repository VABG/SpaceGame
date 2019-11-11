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
        //Make singleton
        totalLevels = 1;
        currentLevel = 0;
        //Move from public to static??? Do I even need to?
        totalLevels = levels.Length;
    }

    public static void AddScore(int score, float timeLeft)
    {
        allTimes[currentLevel] = timeLeft;
        allPoints[currentLevel] = score;
        //NextLevel or GameOver
    }

    public static void AddDeath()
    {
        deaths[currentLevel] += 1;
    }

    public void SetLevel(string level)
    {

    }
}
