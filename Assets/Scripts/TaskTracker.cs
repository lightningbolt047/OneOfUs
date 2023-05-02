using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskTracker : MonoBehaviour
{
    // Define the tasks 
    public static string[] tasks = {"Task 1", "Task 2", "Task 3", "Task 4"};

    // Create a list to track completed tasks
    public static List<string> completedTasks = new List<string>();

    // Reference to the task tracking text on the canvas
    public static GameObject remainingTasksText;

    // Start is called before the first frame update
    void Start()
    {
        TaskTracker.remainingTasksText = GameObject.Find("TaskCounter");
        TaskTracker.remainingTasksText.GetComponent<Text>().text = "Tasks remaining: " + tasks.Length;
        // Example usage of CompleteTask method
        // CompleteTask("Task 2");
        // CompleteTask("Task 1");
        // CompleteTask("Task 4");
        // CompleteTask("Task 3");
    }
    void Update(){
        
    }

    // Function to complete a task and add it to the list of completed tasks
    public static void CompleteTask(string task)
    {
        if (completedTasks.Contains(task))
        {
            Debug.Log("Task " + task + " has already been completed.");
        }
        else
        {
            completedTasks.Add(task);
            Debug.Log("Completed task: " + task);  
        }

        // Calculate the number of remaining tasks
        int remainingTasks = tasks.Length - completedTasks.Count;
        Debug.Log("Tasks remaining: " + remainingTasks);

        // Update the task tracking text on the canvas
        TaskTracker.remainingTasksText.GetComponent<Text>().text = "Tasks remaining: " + remainingTasks;
        //taskTrackingText.text = "Tasks remaining: " + remainingTasks;
        
    }
}

