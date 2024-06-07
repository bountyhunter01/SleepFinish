using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 0.1f;

    private TextMeshProUGUI textBossWarning;

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }
    private IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));

            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0;
        float percent = 0;

        while (percent<1)
        {
            //lerptime시간동안 반복문실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            textBossWarning.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}
