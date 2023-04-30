using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voting : MonoBehaviour
{

    bool hasPlayerAlreadyVoted = false;
    public GameObject playerBannerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void populateCandidates()
    {
        GameObject grid = GameObject.Find("Grid");

        //Code for one person load
        GameObject instantiated=Instantiate(playerBannerPrefab);
        instantiated.transform.parent = grid.transform;
        GameObject childGameObject=instantiated.transform.Find("player_name").gameObject;
        childGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Blue";
        instantiated.GetComponent<votingButton>().playerName = "Blue";
        childGameObject.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(0, 0, 255, 255);

    }


    public void performVote(string playerName,GameObject banner)
    {
        if (!hasPlayerAlreadyVoted)
        {
            hasPlayerAlreadyVoted = true;
            var button=banner.GetComponent<UnityEngine.UI.Image>().color=new Color32(252, 240, 3, 255);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Dont uncomment this, only for testing, call this function once to populate
        //populateCandidates();
    }
}
