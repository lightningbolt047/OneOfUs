using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FlashText : MonoBehaviour
{
    public TMP_Text flashingText;
    public Color onColor = Color.white;
    public Color offColor = Color.black;
    public float flashDuration = 1.0f;

    void Start()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        while (true)
        {
            flashingText.color = onColor;
            yield return new WaitForSeconds(flashDuration / 2.0f);
            flashingText.color = offColor;
            yield return new WaitForSeconds(flashDuration / 2.0f);
        }
    }
}
