using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Startpage : MonoBehaviour
{
    public GameObject txt;
    private float delay = 3f;

    void Start()
    {
        StartCoroutine(HideText(txt, delay));
    }

    IEnumerator HideText(GameObject txt, float delay)
    {
        yield return new WaitForSeconds(delay);
        txt.gameObject.SetActive(false);
    }

}
