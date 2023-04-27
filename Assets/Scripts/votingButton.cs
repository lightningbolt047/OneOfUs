using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class votingButton : MonoBehaviour
{

    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void performVote()
    {
        Debug.Log(playerName);
        GameObject.Find("PollMenu").GetComponent<voting>().performVote(playerName,gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
