using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class TaskTracker : MonoBehaviour
{
    static PhotonView PV;
    // Define the tasks 
    public static string[] tasks = {"Task 1", "Task 2", "Task 3", "Task 4"};

    // Create a list to track completed tasks
    public static List<string> completedTasks = new List<string>();

    // Reference to the task tracking text on the canvas
    public static GameObject remainingTasksText;
    static int remainingTasks;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
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
        if (task == null)
        {
            Debug.LogError("Task name is null");
            return;
        }
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
        remainingTasks = tasks.Length - completedTasks.Count;
        Debug.Log("Tasks remaining: " + remainingTasks);
        PV.RPC("UpdateScore", RpcTarget.All, remainingTasks);
    }

    [PunRPC]
    void UpdateScore(int newScore)
    {
        Debug.Log(newScore);
        // Update the task tracking text on the canvas
        TaskTracker.remainingTasksText.GetComponent<Text>().text = "Tasks remaining: " + newScore;
        // taskTrackingText.text = "Tasks remaining: " + remainingTasks;
    }

    // public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    // {
    //     // When a new player enters the room, send them the current score value
    //     photonView.RPC(remainingTasks, newPlayer, remainingTasks);
    // }
}

