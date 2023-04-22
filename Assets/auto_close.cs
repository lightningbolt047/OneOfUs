using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_close : MonoBehaviour
{
    public float timerDelay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timerDelay -= Time.deltaTime;
            if (timerDelay <= 0f)
            {
                timerDelay = 5f;
                gameObject.SetActive(false);
            }
        }
    }
}
