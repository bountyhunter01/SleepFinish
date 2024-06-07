using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroTextSet : MonoBehaviour
{
    public GameObject introText;


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            introText.SetActive(false);
        }
    }
    //일단은 해제하고 나중에 다시 붙여보자
}
