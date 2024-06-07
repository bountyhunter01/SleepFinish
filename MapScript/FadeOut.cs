using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image screenFlickerAnimator;// 화면 깜빡임 애니메이터
    void Start()
    {
        screenFlickerAnimator = FindObjectOfType<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = screenFlickerAnimator.color;
        if (color.a > 0)
        {
            color.a -= Time.deltaTime;
        }
        //바뀐 색상정보를 저장
        screenFlickerAnimator.color = color;
    }
    public void StartFlickerEffect(float duration)
    {
        StartCoroutine(ToggleFlicker(duration));
    }

    private IEnumerator ToggleFlicker(float duration)
    {
        
        screenFlickerAnimator.enabled = false;
        yield return new WaitForSeconds(duration); // 지정된 시간 동안 대기
      
        screenFlickerAnimator.enabled = true;
    }

}
