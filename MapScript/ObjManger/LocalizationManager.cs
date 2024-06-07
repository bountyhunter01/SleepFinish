using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    bool isChanging;

    public void ChangLocale(int index)
    {
      
        if (isChanging)
            return;
        StartCoroutine(ChangRooution(index));
    }
    //버튼을 눌렀을때 언어가 변경되게 만들기위한 메서드
    IEnumerator ChangRooution(int index)
    {
        isChanging = true;
        // 초기화 상태 확인
        if (!LocalizationSettings.InitializationOperation.IsDone)
        {
           
            yield return LocalizationSettings.InitializationOperation;
        }

      
        //초기화가 안돼서 코루틴이 제대로 실행되지않았다
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
       

        isChanging = false;
    }
}
