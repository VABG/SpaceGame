using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    float timeStaying = 0;
    float timeToGoal = 1.5f; //Time for goal to count
    bool done = false;
    bool inGoal = false;
    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(level != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (inGoal && !done)
        {
            timeStaying += Time.deltaTime;
            if (timeStaying >= timeToGoal)
            {
                LevelCompleted();
                done = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inGoal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inGoal = false;
        timeStaying = 0;
    }

    private void LevelCompleted()
    {
        level.Win();

    }
}
