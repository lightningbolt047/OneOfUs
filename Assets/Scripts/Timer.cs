using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject TaskOverlay;
    public static Timer instance;
    public float timeValue = 120;
    public Text timerText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            TaskOverlay.SetActive(false);
            SceneManager.LoadScene("Loser");
        }

        DisplayTime(timeValue);
        // Check if all tasks have been completed within the two-minute time limit
        if (timeValue > 0 && TaskTracker.completedTasks.Count == TaskTracker.tasks.Length)
        {
            TaskOverlay.SetActive(false);
            SceneManager.LoadScene("Winner");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
