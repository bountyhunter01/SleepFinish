using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    
    public void SceenLoader(string sceenName)
    {
        SceneManager.LoadScene(sceenName);
    }
    public void ResetGame()
    {
        // DontDestroyOnLoad로 설정된 모든 오브젝트를 찾아 파괴
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.scene.name == null)
            {
                Destroy(obj);
            }
        }

        // 새 게임 시작
        SceenLoader("Sleep"); // "StartScene"은 새 게임을 시작할 씬의 이름입니다.
    }

}
