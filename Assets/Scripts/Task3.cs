using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas Q1;
    public Canvas Q2;
    public Canvas Q3;
    public Canvas rule;
    public highlight highlight;
    public Outline outline;
    public Canvas win;

    void Start()
    {
        Q1.GetComponent<Canvas>().enabled = false;
        Q2.GetComponent<Canvas>().enabled = false;
        Q3.GetComponent<Canvas>().enabled = false;
        rule.GetComponent<Canvas>().enabled = false;
        win.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("js3"))
        {
            highlight.enabled = false;
            outline.enabled = false;
            rule.GetComponent<Canvas>().enabled = true;
        }

    }

    public void gototQ1()
    {
        Q1.GetComponent<Canvas>().enabled = true;
        rule.GetComponent<Canvas>().enabled = false;
    }

    public void Ques1_correct()
    {
        Q1.GetComponent<Canvas>().enabled = false;
        Q2.GetComponent<Canvas>().enabled = true;
    }


    public void Ques1_wrong()
    {
        Q1.GetComponent<Canvas>().enabled = false;
        rule.GetComponent<Canvas>().enabled = true;
    }

    public void Ques2_correct()
    {
        Q2.GetComponent<Canvas>().enabled = false;
        Q3.GetComponent<Canvas>().enabled = true;
    }

    public void Ques2_wrong()
    {
        Q2.GetComponent<Canvas>().enabled = false;
        rule.GetComponent<Canvas>().enabled = true;
    }
    public void Ques3_correct()
    {
        Q3.GetComponent<Canvas>().enabled = false;
        Debug.Log("You won");
        win.GetComponent<Canvas>().enabled = true;

    }
    public void makeinteractableagain()
    {
        win.GetComponent<Canvas>().enabled = false;
    }
    public void Ques3_wrong()
    {
        Q3.GetComponent<Canvas>().enabled = false;
        rule.GetComponent<Canvas>().enabled = true;

    }
}
